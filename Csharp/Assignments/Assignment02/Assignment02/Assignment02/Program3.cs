using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    enum days
    {
        Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
    class Program3
    {
        static void Main()
        {
            Console.WriteLine("Enter the number");
            int day_number = Convert.ToInt32(Console.ReadLine());
            days day_word = (days)day_number;
            Console.WriteLine("Day is {0}", day_word);
            Console.Read();
        }
    }
}