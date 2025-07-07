using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateConcessionForTravel
{
    public class Calculate
    {
        const int total_fare = 500;
        public void CalculateConcession(string name, int age)
        {
            if (age <= 5)
            {
                Console.WriteLine($"Name : {name} , Age : {age}  and  Little Champs - Free Ticket");
            }
            else if (age > 60)
            {
                double calculated_fare = total_fare - total_fare * 0.3;
                Console.WriteLine($"Name : {name} , Age : {age} and Senior citizen and Fare: {calculated_fare}");
            }
            else
            {
                Console.WriteLine($"Name :{name} , Age : {age} and Ticket Booked");
            }
        }
    }
}