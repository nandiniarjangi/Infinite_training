using System;


namespace Assessment_1
{
    class LargestNumber
    {
        public void Largest(int a, int b, int c)
        {
            if (a > b && a > c)
            {
                Console.WriteLine("The Largest number is {0}", a);
            }
            else if (b > a && b > c)
            {
                Console.WriteLine("The Largest number is {0}", b);
            }
            else
            {
                Console.WriteLine("The Largest number is {0}", c);
            }
        }
        public static void Main()
        {
            Console.WriteLine("Enter the 1st num: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the 2nd num: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the 3rd num: ");
            int c = Convert.ToInt32(Console.ReadLine());
            LargestNumber ob = new LargestNumber();
            ob.Largest(a, b, c);
            Console.ReadLine();
        }
    }

}
