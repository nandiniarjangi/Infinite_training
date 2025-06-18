using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program5
    {
        //Program to find sum of two numbers and if the 2 numbers are equal then print triple of their sum
        public static void SumAndTriple(int a, int b)
        {
            int sum = a + b;
            if (a == b)
            {
                Console.WriteLine(3 * sum);
            }
            else
            {
                Console.WriteLine(sum);
            }
        }
        public static void Main()
        {
            Console.WriteLine("Enter first number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int b = Convert.ToInt32(Console.ReadLine());
            SumAndTriple(a, b);
            Console.Read();
        }
    }
}