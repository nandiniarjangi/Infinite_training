using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3CSharp
{
    class MethondsnParameters
    {

    }
    class Tester
    {
        public static void SimpleValueMethod(int j)
        {

        }
        // by reference
        //ref is the address
        //using out
        public static int Calculate(int n1,int n2 out int sum,out int product,out int divide)
        {
            sum = n1 + n2;//output value
            product = n1 * n2;//output value
            return n1 - n2;//return value

            
        }
        //parameter array
        public int AddElements(params int[] arr)
        {
            int sum = 0;
            foreach(int n in arr)
            {
                sum += n;
            }
            return sum;
        }
        public static void SimpleRefMethod(ref int j)
        {
            j = 100;
            Console.WriteLine("J's value is" + j);
        }
        static void Main()
        {
            int i = 10;
            MethodsnParameters.SimpleValueMethod(i);
            Console.WriteLine("I's value is {0}", i);
            Console.WriteLine("----with out paramenters");
            int total, prod, difference;

            difference = MethodsnParameters.Calculate(10, 5, out total, out prod);
            Console.WriteLine($"sum of 2 nos is {total},product is {prod},divide is{div}");
            Console.WriteLine("-----Parameter Array-----");
            Console.WriteLine(MethodsnParameters.AddElements(5,6,2));
             Console.Read();


        }
    }
}
