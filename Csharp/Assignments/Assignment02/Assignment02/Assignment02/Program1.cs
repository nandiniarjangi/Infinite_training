using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assignment02
{
    class Program1
    {
        public static void SwapTwoNumbers(int a,int b)
        {
            
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swapping the first is {0} and the second is {1}" ,a, b);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number1:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number2:");
            int b = Convert.ToInt32(Console.ReadLine());
            Program1.SwapTwoNumbers(a, b);
            Console.ReadLine();

        }
    }
}
