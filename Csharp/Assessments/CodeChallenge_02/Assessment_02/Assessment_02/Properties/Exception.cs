using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    class NegativeNumberException : ApplicationException
    {
        public NegativeNumberException(string msg) : base(msg)
        {

        }
    }
    class UserDefinedException
    {
        public void Check_Number(int num)
        {
            try
            {
                if (num < 0)
                {
                    throw (new NegativeNumberException("Enter the Positive Number"));
                }
                else
                {
                    Console.WriteLine("The number is : {0} ", num);
                }
            }
            catch (NegativeNumberException negative_exception)
            {
                Console.WriteLine("Error : " + negative_exception.Message);
            }
        }
        static void Main()
        {
            Console.WriteLine("Enter the number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            UserDefinedException obj = new UserDefinedException();
            obj.Check_Number(number);
            Console.Read();
        }
    }
}