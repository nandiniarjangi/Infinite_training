using System;

namespace RailwayReservationSystem
{
    class User
    {
        public static void UserMenu(int customerId)
        {
            while (true)
            {
                Console.WriteLine("\n----- User Menu -----");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. Cancel Ticket");
                Console.WriteLine("4. Show All Trains");
                Console.WriteLine("5. My Bookings");
                Console.WriteLine("6. Update Profile");
                Console.WriteLine("7. Search Trains by Date");
                Console.WriteLine("8. View Booking History");
                Console.WriteLine("9. View Train Details");
                Console.WriteLine("10. View Upcoming Travel");
                Console.WriteLine("11. Generate Ticket Report");
                Console.WriteLine("12. Exit to Main Menu");
                Console.Write("Choose option: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        UserOperations.RegisterCustomer();
                        break;
                    case 2:
                        UserOperations.BookTrainTicket(customerId);
                        break;
                    case 3:
                        UserOperations.CancelBooking();
                        break;
                    case 4:
                        UserOperations.ShowAllTrains();
                        break;
                    case 5:
                        UserOperations.ShowMyBookings(customerId);
                        break;
                    case 6:
                        UserOperations.UpdateProfile(customerId);
                        break;
                    case 7:
                        UserOperations.SearchTrainsByDate();
                        break;
                    case 8:
                        UserOperations.ViewBookingHistory(customerId);
                        break;
                    case 9:
                        UserOperations.ViewTrainDetails();
                        break;
                    case 10:
                        UserOperations.ViewUpcomingTravel(customerId);
                        break;
                    case 11:
                        UserOperations.GenerateTicketReport();
                        break;
                    case 12:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
