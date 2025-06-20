using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class program2
    {
        public static void Display(int n)
        {
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine("{0} {1} {2} {3} ", n, n, n, n);
                Console.WriteLine("{0}{1}{2}{3} ", n, n, n, n);
            }
            Console.WriteLine();
        }
        public static void Main()
        {
            Console.WriteLine("Enter a number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Output");
            Display(a);
            Console.Read();
        }
    }
}
