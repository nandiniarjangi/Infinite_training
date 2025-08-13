using System;

namespace RailwayReservationSystem
{
    class Admin
    {
        public static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n----- Admin Menu -----");
               
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Update Train");
                Console.WriteLine("3. Delete Train");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Choose option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    

                    case 1:
                        AdminOperations.AddTrain();
                        break;
                    case 2:
                        AdminOperations.UpdateTrain();
                        break;
                    case 3:
                        AdminOperations.DeleteTrain();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}