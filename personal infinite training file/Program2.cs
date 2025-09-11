using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program2
    {
        //Program to find given number is positive or negative
        public static void PostiveOrNegative(int a)
        {
            if (a > 0)
            {
                Console.WriteLine("{0} is a positive number", a);
            }
            else
            {
                Console.WriteLine("{0} is a Negative number", a);
            }

        }
        public static void Main()
        {
            Console.WriteLine("Enter a number");
            int x = Convert.ToInt32(Console.ReadLine());
            Program2.PostiveOrNegative(x);
            Console.Read();
        }
    }
}
