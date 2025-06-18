using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program1
    {
        public static void EqualOrNot(int a, int b)
        {
            if (a == b)
            {
                Console.WriteLine("{0} and {1} are equal", a, b);
            }
            else
            {
                Console.WriteLine("{0} and {1} are not equal", a, b);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1st number:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd number:");
            int b = Convert.ToInt32(Console.ReadLine());
            Program1.EqualOrNot(a, b);
            Console.Read();

        }
    }
}