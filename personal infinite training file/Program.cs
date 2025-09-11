using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.GoToEg();
            Console.Read();
            public void GotoEg()
            {
                Console.WriteLine("First statement");
                goto infinite;
                Console.WriteLine("Second statement");
                Console.WriteLine("Third statement");
            infinite:
                Console.WriteLine("Infinite welcomes all new people");
                goto label1;
                Console.WriteLine("you are here");
                Console.WriteLine("see you soon");
            label1:
                Console.WriteLine("Hello");
            doagain:
                Console.WriteLine("Enter a number lss than 10");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num >= 10)
                {
                    Console.WriteLine("Number should be less than 10");
                    goto doagain;
                }
                Console.WriteLine(num + "is less than 10");



            }

        }
    }
}
