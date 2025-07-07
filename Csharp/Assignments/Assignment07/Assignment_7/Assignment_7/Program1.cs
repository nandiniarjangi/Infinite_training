using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{



    
//Write a query that returns list of numbers and their squares only if square is greater than 20 

//Example input[7, 2, 30]
//Expected output
//→ 7 - 49, 30 - 900
    
    
    
    class Program1
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Console.WriteLine("Enter the number of elements in the list : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the {0} element n the list : ", i + 1);
                int element = Convert.ToInt32(Console.ReadLine());
                list.Add(element);
            }
            Console.WriteLine("The elements in the list are : ");
            foreach (int a in list)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            var square = list.Select(x => x * x).Where(x => x * x > 20);
            Console.WriteLine("The elements in the Square list are : ");
            foreach (var s in square)
            {
                Console.Write(s + " ");
            }
            Console.Read();
        }
    }
}