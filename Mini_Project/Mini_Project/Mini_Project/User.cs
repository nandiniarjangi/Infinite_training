using System;

namespace RailwayReservationSystem
{
    class User
    {
        public static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n----- User Menu -----");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. Cancel Ticket");
                Console.WriteLine("4. Show All Trains");
                Console.WriteLine("5. My Bookings");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Choose option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        UserOperations.RegisterCustomer();
                        break;
                    case 2:
                        UserOperations.BookTrainTicket();
                        break;
                    case 3:
                        UserOperations.CancelBooking();
                        break;
                    case 4:
                        UserOperations.ShowAllTrains();
                        break;
                    case 5:
                        UserOperations.ShowMyBookings();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}

