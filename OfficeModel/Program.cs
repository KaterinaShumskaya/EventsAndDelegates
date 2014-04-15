using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeModel
{
    class Program
    {
        
        class OfficeEventListener
        {
            private IList<Person> _persons;

            private Person _person;

            public OfficeEventListener(Person person, IList<Person> persons)
            {
                _persons = persons;
                _person = person;
                _person.ComeEvent += new PersonEventHandler(PersonCame);
                _person.LeftEvent += new PersonEventHandler(PersonLeft);
            }

            private void PersonLeft(object sender, EmployeeEventArgs e)
            {
                _persons.Remove(e.Person);
                foreach (var person in _persons)
                {
                    person.SayGoodBye(e.Person);
                }          
            }

            private void PersonCame(object sender, EmployeeEventArgs e)
            {
                foreach (var person in _persons)
                {
                    person.SayHello(e.Person, e.Time);
                }
                _persons.Add(e.Person);
            }

            public void Detach()
            {
                // Detach the event and delete the list
                _person.ComeEvent -= new PersonEventHandler(PersonCame);
                _person.LeftEvent -= new PersonEventHandler(PersonLeft);
                _person = null;
            }
        }
      
        static void Main(string[] args)
        {
            var persons = new List<Person>();
            var person1 = new Person("Петя");
            var person2 = new Person("Вова");
            var person3 = new Person("Дима");
            OfficeEventListener officeEventListener1 = new OfficeEventListener(person1, persons);
            OfficeEventListener officeEventListener2 = new OfficeEventListener(person2, persons);
            OfficeEventListener officeEventListener3 = new OfficeEventListener(person3, persons);
            person3.Come(new DateTime(2014, 04, 22, 18, 24, 00));
            person1.Come(new DateTime(2014, 04, 22, 10, 24, 00));
            person2.Come(new DateTime(2014, 04, 22, 13, 24, 00));
            
            Console.ReadLine();

        }
    }
}
