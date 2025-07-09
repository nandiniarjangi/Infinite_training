using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_03
{
    class Box
    {
        public int length;
        public int breadth;
        public Box(int l, int b)
        {
            length = l;
            breadth = b;
        }
        public static Box operator +(Box b1, Box b2)
        {
            return new Box(b1.length + b2.length, b1.breadth + b2.breadth);
        }
    }
    class Program_2
    {
        static void Main()
        {
            Console.WriteLine("-------Entering first object length and breadth------");
            Console.WriteLine("Enter the length of first object : ");
            int len1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the breadth of first object: ");
            int bre1 = Convert.ToInt32(Console.ReadLine());
            Box b1 = new Box(len1, bre1);
            Console.WriteLine("-------Entering Second object length and breadth------");
            Console.WriteLine("Enter the length of second object : ");
            int len2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the breadth of second object: ");
            int bre2 = Convert.ToInt32(Console.ReadLine());
            Box b2 = new Box(len2, bre2);
            Box b3 = b1 + b2;
            Console.WriteLine($"Sum of lengths : {b3.length} and sum of breadths : {b3.breadth} ");
            Console.Read();
        }
    }
    
}


