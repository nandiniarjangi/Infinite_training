using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    //Program to perform given mathematical operation
    class Program3
    {
        public static void Calculations(int a, char op, int b)
        {
            switch (op)
            {

                case '+':
                    Console.WriteLine(a + b);
                    break;
                case '-':
                    Console.WriteLine(a - b);
                    break;
                case '*':
                    Console.WriteLine(a * b);
                    break;
                case '/':
                    Console.WriteLine(a / b);
                    break;
                default:
                    Console.WriteLine("Invalid Operator");
                    break;

            }
        }
        public static void Main()
        {
            Console.WriteLine("Input first number");
            int p = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the Operator");
            char op = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Input second number");
            int q = Convert.ToInt32(Console.ReadLine());
            Program3.Calculations(p, op, q);

            Console.Read();
        }
    }
}