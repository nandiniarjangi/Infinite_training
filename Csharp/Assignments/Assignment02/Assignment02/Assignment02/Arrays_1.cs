using System;


namespace Assignment_2
{
    class Arrays_1
    {
        public static float Average(int[] arr)
        {
            int sum = 0;
            float avg;
            foreach (int i in arr)
            {
                sum = sum + i;
            }
            avg = sum / arr.Length;
            return avg;
        }
        public static void MinAndMax(int[] arr)
        {
            Array.Sort(arr);
            int min = arr[0];
            int max = arr[arr.Length - 1];
            Console.WriteLine("Minimum value in the array is {0}", min);
            Console.WriteLine("Maximum value in the array is {0}", max);
        }
        public static void Main()
        {
            int[] arr = new int[] { 10, 60, 90, 30, 100 };
            Console.WriteLine("Average value of array elements is {0}", Average(arr));
            MinAndMax(arr);
            Console.Read();
        }
    }
}