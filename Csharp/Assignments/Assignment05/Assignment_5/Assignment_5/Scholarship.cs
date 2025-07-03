using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2.Create a class called Scholarship which has a function Public void Merit() that takes marks and fees as an input. 
//If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
//If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
//If the given mark is >90, then calculate scholarship amount as 50% of the fees.
//In all the cases return the Scholarship amount, else throw an user exception

namespace Assignment_5
{
    class Scholarship
    {
        double Scholarship_amount;
        public void Merit(int marks, double fees)
        {
            if (marks >= 70 && marks <= 80)
            {
                Scholarship_amount = fees * (double)20 / 100;
            }
            else if (marks > 80 && marks <= 90)
            {
                Scholarship_amount = fees * (double)30 / 100;
            }
            else if (marks > 90)
            {
                Scholarship_amount = fees * (double)50 / 100;
            }
            Console.WriteLine("Scholarship amount is {0} ", Scholarship_amount);
        }
        public static void Main()
        {
            Console.WriteLine("Enter the marks of the student :");
            int marks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the fees of the student :");
            double fees = Convert.ToDouble(Console.ReadLine());
            Scholarship s = new Scholarship();
            s.Merit(marks, fees);

            Console.Read();
        }

    }
}
