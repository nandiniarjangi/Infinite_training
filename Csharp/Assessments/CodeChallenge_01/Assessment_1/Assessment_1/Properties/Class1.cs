using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class ExchangeCharacters
     {
        public static string ExchangeFirstAndLastCharacters(string str)
        {
            char[] arr = str.ToCharArray();
            char temp = ' ';
            int n = str.Length;
            temp = arr[0];
            arr[0] = arr[n - 1];
            arr[n - 1] = temp;
            string res = string.Join("", arr);
            return res;
        }
        public static void Main()
        {
            Console.WriteLine("Enter the String: ");
            string str = Console.ReadLine();
            Console.WriteLine(" The output String after  exchanging first and last characters is {0} ",ExchangeFirstAndLastCharacters(str));
            Console.Read();
            
        }
    }
}
