namespace Lab7
{
    partial class ConverterForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.currencyBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currencyToBox = new System.Windows.Forms.ComboBox();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.finallyPrice = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите сумму: ";
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(108, 6);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(77, 20);
            this.priceBox.TabIndex = 1;
            this.priceBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.priceBox_MouseClick);
            this.priceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceBox_KeyPress);
            // 
            // currencyBox
            // 
            this.currencyBox.AllowDrop = true;
            this.currencyBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.currencyBox.FormattingEnabled = true;
            this.currencyBox.Location = new System.Drawing.Point(208, 5);
            this.currencyBox.Name = "currencyBox";
            this.currencyBox.Size = new System.Drawing.Size(83, 21);
            this.currencyBox.TabIndex = 2;
            this.currencyBox.Text = "Валюта:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите валюту: ";
            // 
            // currencyToBox
            // 
            this.currencyToBox.FormattingEnabled = true;
            this.currencyToBox.Location = new System.Drawing.Point(15, 70);
            this.currencyToBox.Name = "currencyToBox";
            this.currencyToBox.Size = new System.Drawing.Size(94, 21);
            this.currencyToBox.TabIndex = 6;
            this.currencyToBox.Text = "Валюта:";
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Location = new System.Drawing.Point(141, 47);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(44, 13);
            this.summaryLabel.TabIndex = 7;
            this.summaryLabel.Text = "Сумма:";
            // 
            // finallyPrice
            // 
            this.finallyPrice.AutoSize = true;
            this.finallyPrice.Location = new System.Drawing.Point(141, 78);
            this.finallyPrice.Name = "finallyPrice";
            this.finallyPrice.Size = new System.Drawing.Size(0, 13);
            this.finallyPrice.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Конвертировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(247, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "<-->";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 133);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.finallyPrice);
            this.Controls.Add(this.summaryLabel);
            this.Controls.Add(this.currencyToBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currencyBox);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.label1);
            this.Name = "ConverterForm";
            this.Text = "Конвертер валют";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.ComboBox currencyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox currencyToBox;
        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.Label finallyPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

