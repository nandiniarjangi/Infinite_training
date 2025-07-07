using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculateConcessionForTravel;

//Create a class library with a function CalculateConcession()  that takes age as an input and calculates concession for travel as below:
//If age <= 5 then “Little Champs - Free Ticket” should be displayed
//If age > 60 then calculate 30% concession on the totalfare(Which is a constant Eg:500 / -) and Display “ Senior Citizen” + Calculated Fare
//Else “Print Ticket Booked” + Fare.


namespace Assignment_7
{
    class Program_4
    {
        const int total_fare = 500;
        static string Name;
        static int Age;
        static void Main()
        {
            Console.WriteLine("Enter the name : ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter the age :");
            Age = Convert.ToInt32(Console.ReadLine());
            Calculate obj = new Calculate();
            obj.CalculateConcession(Name, Age);
            Console.Read();
        }
    }
}
