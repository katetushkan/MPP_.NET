using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Lab7
{
    public partial class ConverterForm :Form
    {
        public List<Currency> currencies;
        public List<Rates> rates;
        public ConverterForm()
        {
            InitializeComponent();
            currencies = InitializatorForm(currencies);
            rates = InitializeRetes(rates);
            
        }

        public List<Currency> InitializatorForm(List<Currency> currencies)
        {
            try
            {
                WebRequest request = WebRequest.Create("http://www.nbrb.by/api/exrates/rates?periodicity=0");
                WebResponse response = request.GetResponse();
                Stream newStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(newStream);
                var result = sr.ReadToEnd();
                currencies = JsonConvert.DeserializeObject<List<Currency>>(result);
               
                
            }
            catch(Exception)
            {
                
                    MessageBox.Show("Ошибка подключения к сети");
                  
                
            }
            foreach(Currency currency in currencies)
                {
                currencyBox.Items.Add(currency.Cur_Name);
                currencyToBox.Items.Add(currency.Cur_Name);
            }

            return currencies;
            

         
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currencyBox.Text == "Валюта:" || currencyToBox.Text == "Валюта:" || priceBox.Text == "")
            {
                MessageBox.Show("Введите недостающие данные");

            }
           
            else
            {
                finallyPrice.Text = RateProcess(currencies, rates).ToString();
            }

            
        }


        public List<Rates> InitializeRetes(List<Rates> rates)
        {
            try
            {
                WebRequest request1 = WebRequest.Create("http://www.nbrb.by/api/exrates/rates?periodicity=0");
                WebResponse response1 = request1.GetResponse();
                Stream newStream1 = response1.GetResponseStream();
                StreamReader sr1 = new StreamReader(newStream1);
                var result1 = sr1.ReadToEnd();
                rates = JsonConvert.DeserializeObject<List<Rates>>(result1);
            }
                
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к сети");
            }
         
            return rates;
        }

        public decimal? RateProcess(List<Currency> currencies, List<Rates> rates)
        {
            
                Rates rateFrom = null;
                Rates rateTo = null;
                foreach (Rates rate in rates)
                {
                    if (rate.Cur_Name == currencyBox.Text)
                    {
                        rateFrom = rate;
                    }
                    if (rate.Cur_Name == currencyToBox.Text)
                    {
                        rateTo = rate;
                    }

                }
                decimal initPrice = Convert.ToDecimal(priceBox.Text);
                var final1 = rateFrom.Cur_OfficialRate * initPrice * rateTo.Cur_Scale / (rateFrom.Cur_Scale * rateTo.Cur_OfficialRate);
                decimal final = final1 ?? 0;
                final = decimal.Round(final, 3);



            return final;

        }

        private void priceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            
            if (e.KeyChar.Equals(','))
            {
                e.Handled = tb.SelectionStart == 0 || tb.Text.IndexOf(",") != -1;
                if (!e.Handled)
                {
                    return;
                }
            }
          

            e.Handled = !char.IsNumber(e.KeyChar);
        }

        private void priceBox_MouseClick(object sender, MouseEventArgs e)
        {
            priceBox.Text = "";
            finallyPrice.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var temp1 = currencyBox.Text;
            var temp2 = currencyToBox.Text;
            var temp3 = priceBox.Text;
            var temp4 = finallyPrice.Text;
            currencyToBox.Text = temp1;
            currencyBox.Text = temp2;
            priceBox.Text = temp4;
            finallyPrice.Text = temp3;
        }

       
    }   
       
   
}
