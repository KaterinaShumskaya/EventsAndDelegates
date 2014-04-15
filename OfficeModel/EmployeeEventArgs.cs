using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeModel
{
    public class EmployeeEventArgs: EventArgs
    {
        public EmployeeEventArgs(Person person)
        {
            Person = person;
        }

        public EmployeeEventArgs(Person person, DateTime time) : this(person)
        {
            Time = time;
        }

        public Person Person { get; protected set; }

        public DateTime Time { get; protected set; }
    }
}
