using RailwayReservationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Mini_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("****************************************WELCOME TO RAILWAY RESERVATION SYSTEM**************************************");
                Console.WriteLine("Choose the below options : ");
                Console.WriteLine("1.Admin\n2.User\n3.Exit");
                Console.Write("Choose an option: ");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {

                   

                    case 1:
                        Admin.AdminMenu();
                        break;
                    case 2:
                        User.UserMenu();
                        break;
                    case 3:
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid Option.Choose correct option");
                        break;
                }
            }
           Console.Read();
            
        }
    }
}




