using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class Program
    {
        public class StringComparer: IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x.Length > y.Length)
                {
                    return 1;
                }

                if (x.Length == y.Length)
                {
                    var i = 0;
                    while (i < x.Length)
                    {
                       if (x[i] > y[i])
                       {
                           return 1;
                       }

                       if (x[i] < y[i])
                       {
                           return -1;
                       }

                       i++;
                    }

                    return 0;
                }

                return -1;
            }
        }

        public static void Sort(string[] arr)
        {
            Array.Sort(arr, new StringComparer());
        }

        public delegate void Sorting(string[] arr);

        static void Main(string[] args)
        {
            Sorting sorting = Sort;
            string[] arr = { "ddddffffff", "asdf", "sdfsdfsdf", "asdz" };
            sorting(arr);
            foreach (var s in arr)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
