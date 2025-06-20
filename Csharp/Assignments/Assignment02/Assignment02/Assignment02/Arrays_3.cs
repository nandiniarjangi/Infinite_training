using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignment_2
{
    class Arrays_3
    {
        public static void Main()
        {
            Console.WriteLine("Enter the size of the array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array1 = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter the element {i + 1}:");
                array1[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Elements of the first array : ");
            for (int x = 0; x < n; x++)
            {
                Console.Write(array1[x] + " ");
            }
            Console.WriteLine();
            int[] array2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                array2[i] = array1[i];
            }
            Console.Write("Elements of the second array :");
            for (int x = 0; x < n; x++)
            {
                Console.Write(array2[x] + " ");
            }
            Console.Read();
        }
    }
}