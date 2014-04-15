using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeModel
{
    public delegate void PersonEventHandler(object sender, EmployeeEventArgs e);

    public class Person
    {
        
        public Person(string name)
        {
            Name = name;
        }

        public event PersonEventHandler ComeEvent;
        public event PersonEventHandler LeftEvent;


        protected virtual void OnCame(EmployeeEventArgs e)
        {
            if (ComeEvent != null)
                ComeEvent(this, e);
        }

        protected virtual void OnLeft(EmployeeEventArgs e)
        {
            if (LeftEvent != null)
                LeftEvent(this, e);
        }

        public void Come(DateTime time)
        {
            Console.WriteLine("{0} пришёл на работу", Name);
            this.OnCame(new EmployeeEventArgs(this, time));
        }

        public void Left()
        {
            Console.WriteLine("{0} ушёл с работы", Name);
            this.OnLeft(new EmployeeEventArgs(this));
        }

        public string Name { get; set; }

        public void SayHello(Person person, DateTime time)
        {
            string greeting;
            if (time.Hour < 12)
            {
                greeting = "Доброе утро";
            }
            else if (time.Hour > 12 && time.Hour < 17)
            {
                greeting = "Добрый день";
            }
            else
            {
                greeting = "Добрый вечер";
            }

            Console.WriteLine("\"{0},{1}!\", - сказал {2}", greeting, person.Name, Name); 
        }

        public void SayGoodBye(Person person)
        {
            Console.WriteLine("\"До свидания,{0}!\", - сказал {1}", person.Name, Name);  
        }
    }
}
