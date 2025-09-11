using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass2practice
{
    //Write a program in C# to accept a word from the user and display the reverse of it. 
    class Class1
    {
        public static void isequal(string str1, String str2)
        {

            if (str1.Equals(str2))
            {
                Console.WriteLine("Both strings are equal");
            }
            else
            {
                Console.WriteLine("Both strings are not equal");

            }
        }


        public static void Main()
        {
            Console.WriteLine("Enter a word1:");

            String str1 = Console.ReadLine();
            Console.WriteLine("Enter a word2:");
            String str2 = Console.ReadLine();

            isequal(str1, str2);
            Console.ReadLine();
        }
    }

}
