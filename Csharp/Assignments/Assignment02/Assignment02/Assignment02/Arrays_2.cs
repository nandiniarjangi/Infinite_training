using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Arrays_2
    {
        public static void TotalAndAverage(int[] marks)
        {
            int sum = 0;
            int avg;
            foreach (int i in marks)
            {
                sum = sum + i;
            }
            avg = sum / marks.Length;
            Console.WriteLine("Total of the marks is {0}", sum);
            Console.WriteLine("Average of the marks is {0}", avg);
        }
        public static void MinAndMax(int[] marks)
        {
            Array.Sort(marks);
            int min = marks[0];
            int max = marks[marks.Length - 1];
            Console.WriteLine("Minimum value in the array is {0}", min);
            Console.WriteLine("Maximum value in the array is {0}", max);
        }
        public static void AscendingOrder(int[] marks)
        {
            Array.Sort(marks);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(marks[i] + " ");
            }
        }
        public static void DescendingOrder(int[] marks)
        {
            Array.Reverse(marks);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(marks[i] + " ");
            }
        }
        public static void Ascending_Descending_Without_Predefined_Func(int[] marks)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    if (marks[i] > marks[j])
                    {
                        int temp = marks[i];
                        marks[i] = marks[j];
                        marks[j] = temp;

                    }
                }
            }
            Console.WriteLine("Ascending order without predefined functions");
            foreach (int x in marks)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Descending order without predefined functions");
            for (int k = 9; k >= 0; k--)
            {
                Console.Write(marks[k] + " ");
            }
        }

        public static void Main()
        {
            int[] marks = new int[10];
            Console.WriteLine("Enter the marks");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"enter the element {i + 1} : ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            TotalAndAverage(marks);
            MinAndMax(marks);
            Console.WriteLine("Ascending order of marks:");
            AscendingOrder(marks);
            Console.WriteLine();
            Console.WriteLine("Descending order of marks:");
            DescendingOrder(marks);
            Console.WriteLine();
            Ascending_Descending_Without_Predefined_Func(marks);
            Console.Read();
        }
    }
}