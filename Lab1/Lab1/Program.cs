using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    

    class Program
    {
        static void Main(string[] args)
        {
            
            var students = new List<Student>();
            Decanat stock = new Decanat(students);
            Student Vasia = new Student("Vasia", "751000", stock);



            
            Student Vasia1 = new Student("Vasia1", "751001", stock);
           
            Student Vasia2 = new Student("Vasia2", "751002", stock);
            Student Vasia3 = new Student("Vasia3", "751003", stock);
            Student Vasia4 = new Student("Vasia4", "751004", stock);
            students.Add(Vasia);
            students.Add(Vasia1);
            students.Add(Vasia2);
            students.Add(Vasia3);
            students.Add(Vasia4);
            foreach(var stud in students)
            {
                stud.Actions += stock.Sub;
            }
         
            int choice = 1;
            while(choice > 0)
            {
                Console.WriteLine("Введите: 1-подписать студента на событие \"Начало выдачи ведомостичек\" /n 2-подписать студента на событие \"Начало выдачи ведомостичек  старост\" /n 3-подписать студента на событие \"Начало сезона отчислений\" /n 4 - список подписок студентов /n 5 - удалить событие из списка подписок заданного студента событие \"Начало выдачи ведомостичек\" /n 6-оповестить  студента о событии \"Начало выдачи ведомостичек\" /n 7-оповестить студента о событии \"Начало выдачи ведомостичек  старост\" /n 8-оповестить студента о событии \"Начало сезона отчислений\" /n 9 - удалить событие из списка подписок заданного студента \"Начало выдачи ведомостичек  старост\" /n 10 - удалить событие из списка подписок заданного студента \"Начало сезона отчислений\" /n 0 - завершение работы программы");
                int switchParam = Convert.ToInt32(Console.ReadLine());
                switch (switchParam)
                {
                    case 0:
                        choice = -1;
                        break;

                    case 1:
                        Console.WriteLine("Введите имя студента ");
                        string name = Console.ReadLine();
                        var studentSubscribe = students.FirstOrDefault(student => student.Name == name);
                        studentSubscribe.Actions += stock.StarVedomost;
                        break;
                    case 2:
                        Console.WriteLine("Введите имя студента ");
                        string name1 = Console.ReadLine();
                        var studentSubscribe1 = students.FirstOrDefault(student => student.Name == name1);
                        studentSubscribe1.Actions += stock.VedomostForHeadStudent;
                        break;
                    case 3:
                        Console.WriteLine("Введите имя студента ");
                        string name2 = Console.ReadLine();
                        var studentSubscribe2 = students.FirstOrDefault(student => student.Name == name2);
                        studentSubscribe2.Actions += stock.StarSeccionTime;
                        break;
                    case 4:
                        foreach (var student in students)
                        {
                            Console.Write(student.Name + " ");
                            Console.WriteLine(student.GroupNumber);
                            if (student.Actions.Target != null)
                            {
                                foreach (var method in student.Actions.GetInvocationList())
                                {
                                    Console.Write(method.Method.Name + " ");
                                }
                                Console.WriteLine();
                            }
                           
                        }
                        break;
                    case 6:
                        stock.StarVedomost();
                        break;
                    case 7:
                        stock.VedomostForHeadStudent();
                        break;
                    case 8:
                        stock.StarSeccionTime();
                        break;
                    case 10:
                        Console.WriteLine("Введите имя студента ");
                        string name3 = Console.ReadLine();
                        var studentSubscribe3 = students.FirstOrDefault(student => student.Name == name3);
                        studentSubscribe3.Actions -= stock.StarSeccionTime;
                        break;
                    case 9:
                        Console.WriteLine("Введите имя студента ");
                        string name4 = Console.ReadLine();
                        var studentSubscribe4 = students.FirstOrDefault(student => student.Name == name4);
                        studentSubscribe4.Actions -= stock.VedomostForHeadStudent;
                        break;
                    case 5:
                        Console.WriteLine("Введите имя студента ");
                        string name5 = Console.ReadLine();
                        var studentSubscribe5 = students.FirstOrDefault(student => student.Name == name5);
                        studentSubscribe5.Actions -= stock.StarVedomost;
                        break;




                }
            }
            

            Console.ReadLine();
        }
    }

    class Student : IObserver
    {

        IObservable _decanat;
        public string Name { get; set; }
        public string GroupNumber { get; set; }
        public Action Actions { get; set; } 

        public Student(string name, string groupNumber, IObservable decanat)
        {
            Name = name;
            GroupNumber = groupNumber;
          
            _decanat = decanat;
            _decanat.RegisterObserver(this);
           
        }

        
        public void Update(object ob)
        {
            var not = ob as NotifierInfo;
            if (not != null) 
            {
                foreach (Action action in this.Actions.GetInvocationList())
                {
                    if (action.Method.Name == not.MethodName)
                    {
                        Console.WriteLine(this.Name + " " + this.GroupNumber + " " + not.MethodName);
                    }
                }
            }
            
        }
    }

    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
        void StarVedomost();
        void VedomostForHeadStudent();
        void StarSeccionTime();
    }
    class NotifierInfo
    {
        public string MethodName { get; set; }

    }

    class Decanat : IObservable
    {

        public NotifierInfo notifierInfo;
        
        List<IObserver> observers;
        public Decanat(IReadOnlyList<IObserver> student)
        {
            notifierInfo = new NotifierInfo();
            observers = new List<IObserver>();
            
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(notifierInfo);
            }
        }

        public void StarVedomost()
        {
            notifierInfo.MethodName = "StarVedomost";
            NotifyObservers();

        }
        public void Sub()
        {

        }

        public void VedomostForHeadStudent()
        {
            notifierInfo.MethodName = "VedomostForHeadStudent";
            NotifyObservers();
           
        }

        public void StarSeccionTime()
        {
            notifierInfo.MethodName = "StarSeccionTime";
            NotifyObservers();
            
        }
    }
}
