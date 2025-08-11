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
                Console.WriteLine("1.Admin Login");
                Console.WriteLine("2. Add Train");
                Console.WriteLine("3. Update Train");
                Console.WriteLine("4. Delete Train");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AdminOperations.AdminLogin();
                        break;

                    case 2:
                        AdminOperations.AddTrain();
                        break;
                    case 3:
                        AdminOperations.UpdateTrain();
                        break;
                    case 4:
                        AdminOperations.DeleteTrain();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}