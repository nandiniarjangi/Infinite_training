using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_03
{
    delegate int CalculatorDelegate(int a, int b);
    class Calculator
    {
        public static void Operations(int a, int b, CalculatorDelegate add)
        {
            int result = add(a, b);
            Console.WriteLine(result);
        }
        public static int Addition(int a, int b)
        {
            return a + b;
        }
        public static int Subtraction(int a, int b)
        {
            return a - b;
        }
        public static int Multiplication(int a, int b)
        {
            return a * b;
        }
        static void Main()
        {
            Console.WriteLine("Enter first number : ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second number : ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Addition of two numbers :");
            Operations(x, y, Addition);
            Console.WriteLine("Subtraction of two numbers :");
            Operations(x, y, Subtraction);
            Console.WriteLine("Multiplication of two numbers :");
            Operations(x, y, Multiplication);
            Console.Read();
        }

    }
}

