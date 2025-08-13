using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RailwayReservationSystem
    {
        class UserOperations
        {
            static SqlConnection GetConnection()
            {
                SqlConnection con = new SqlConnection("Data Source=ICS-LT-6ZKZC64\\SQLEXPRESS;database=MiniProject;user id=sa;password=@nandini428647");
                con.Open();
                return con;
            }

            public static bool UserLogin(out int customerId)
            {
                customerId = -1;
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SELECT CustId FROM Customers WHERE MailId = @mail AND Password = @pass AND IsActive = 1", con);
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@pass", password);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        customerId = Convert.ToInt32(result);
                        Console.WriteLine("Login successful.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid credentials.");
                        return false;
                    }
                }
            }

            public static void RegisterCustomer()
            {
                using (SqlConnection con = GetConnection())
                {
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Email: ");
                    string mail = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Customers (CustName, Phone, MailId, Password) OUTPUT INSERTED.CustId VALUES (@name, @phone, @mail, @pass)", con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@pass", password);

                    int id = (int)cmd.ExecuteScalar();
                    Console.WriteLine($"Registration successful. Your Customer ID: {id}");
                }
            }

            public static void UpdateProfile(int customerId)
            {
                using (SqlConnection con = GetConnection())
                {
                    Console.Write("Enter New Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter New Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Enter New Password: ");
                    string password = Console.ReadLine();

                    SqlCommand cmd = new SqlCommand("UpdateCustomerProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custid", customerId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Profile updated successfully.");
                }
            }

            public static void SearchTrainsByDate()
            {
                using (SqlConnection con = GetConnection())
                {
                    Console.Write("Enter Source: ");
                    string source = Console.ReadLine();
                    Console.Write("Enter Destination: ");
                    string destination = Console.ReadLine();
                    Console.Write("Enter Travel Date (yyyy-mm-dd): ");
                    DateTime travelDate = DateTime.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("SearchTrainsByDate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@source", source);
                    cmd.Parameters.AddWithValue("@destination", destination);
                    cmd.Parameters.AddWithValue("@travelDate", travelDate);

                    SqlDataReader dr = cmd.ExecuteReader();
                    Console.WriteLine("TrainNo | Name | Class | Seats | Cost");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["train_no"]} | {dr["train_name"]} | {dr["class"]} | {dr["availability"]} | {dr["cost"]}");
                    }
                    dr.Close();
                }
            }

            public static void ViewBookingHistory(int customerId)
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("GetBookingHistory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custid", customerId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    Console.WriteLine("BookingId | TrainNo | Class | Seats | Cost | TravelDate | Cancelled | Refund");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["BookingId"]} | {dr["Train_No"]} | {dr["Class"]} | {dr["NoOfTickets"]} | {dr["TotalCost"]} | {dr["TravelDate"]} | {(Convert.ToBoolean(dr["IsCancelled"]) ? "Yes" : "No")} | {dr["RefundAmount"] ?? 0}");
                    }
                    dr.Close();
                }
            }

            public static void ViewTrainDetails()
            {
                using (SqlConnection con = GetConnection())
                {
                    Console.Write("Enter Train Number: ");
                    int trainNo = int.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("GetTrainDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@train_no", trainNo);

                    SqlDataReader dr = cmd.ExecuteReader();
                    Console.WriteLine("TrainNo | Name | Source | Destination | Class | Seats | Cost");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["train_no"]} | {dr["train_name"]} | {dr["source"]} | {dr["destination"]} | {dr["class"]} | {dr["availability"]} | {dr["cost"]}");
                    }
                    dr.Close();
                }
            }

            public static void ViewUpcomingTravel(int customerId)
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("GetUpcomingTravel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custid", customerId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    Console.WriteLine("BookingId | TrainNo | Class | Seats | TravelDate");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["BookingId"]} | {dr["Train_No"]} | {dr["Class"]} | {dr["NoOfTickets"]} | {dr["TravelDate"]}");
                    }
                    dr.Close();
                }
            }

            public static void GenerateTicketReport()
            {
                using (SqlConnection con = GetConnection())
                {
                    Console.Write("Enter Booking ID: ");
                    int bookingId = int.Parse(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand("GetTicketReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    Console.WriteLine("\n--- Ticket Report ---");
                    while (dr.Read())
                    {
                        Console.WriteLine($"Booking ID   : {dr["BookingId"]}");
                        Console.WriteLine($"Train No     : {dr["Train_No"]} - {dr["Train_Name"]}");
                        Console.WriteLine($"Class        : {dr["Class"]}");
                        Console.WriteLine($"Seats        : {dr["NoOfTickets"]}");
                        Console.WriteLine($"Total Cost   : {dr["TotalCost"]}");
                        Console.WriteLine($"Booking Date : {Convert.ToDateTime(dr["BookingDate"]).ToShortDateString()}");
                        Console.WriteLine($"Travel Date  : {Convert.ToDateTime(dr["TravelDate"]).ToShortDateString()}");
                        Console.WriteLine($"Cancelled    : {(Convert.ToBoolean(dr["IsCancelled"]) ? "Yes" : "No")}");
                        Console.WriteLine($"Refund       : {dr["RefundAmount"] ?? 0}");
                        Console.WriteLine($"Passenger    : {dr["PassengerName"]} | {dr["Gender"]} | Age: {dr["Age"]}");
                        Console.WriteLine("--------------------------------------------------");
                    }
                    dr.Close();
                }
            }


            public static void BookTrainTicket(int customerId)
            {
                using (SqlConnection con = GetConnection())
                {
                    Console.Write("Enter Source: ");
                    string src = Console.ReadLine();
                    Console.Write("Enter Destination: ");
                    string dest = Console.ReadLine();

                    SqlCommand cmd = new SqlCommand("SelectTrain", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tsource", src);
                    cmd.Parameters.AddWithValue("@tdestination", dest);

                    SqlDataReader dr = cmd.ExecuteReader();
                    Console.WriteLine("TrainNo | Name | Class | Seats | Cost");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["Train_No"]} | {dr["Train_Name"]} | {dr["Class"]} | {dr["Availability"]} | {dr["Cost"]}");
                    }
                    dr.Close();

                    Console.Write("Enter Train No: ");
                    int tno = int.Parse(Console.ReadLine());
                    Console.Write("Enter Class: ");
                    string cls = Console.ReadLine();
                    Console.Write("Enter Number of Seats: ");
                    int seats = int.Parse(Console.ReadLine());
                DateTime travelDate;
                while (true)
                {
                    Console.Write("Enter Travel Date (yyyy-mm-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out travelDate))
                    {
                        if (travelDate.Date >= DateTime.Today)
                        {
                            break; // valid date
                        }
                        else
                        {
                            Console.WriteLine("Invalid date. Travel date must be today or in the future.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Please enter the date in yyyy-mm-dd format.");
                    }
                }


                // Book the ticket
                SqlCommand book = new SqlCommand("BookTickets", con);
                    book.CommandType = CommandType.StoredProcedure;
                    book.Parameters.AddWithValue("@tno", tno);
                    book.Parameters.AddWithValue("@cid", customerId);
                    book.Parameters.AddWithValue("@tclass", cls);
                    book.Parameters.AddWithValue("@seats", seats);
                    book.Parameters.AddWithValue("@travelDate", travelDate);

                    SqlParameter status = new SqlParameter("@status", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output };
                    book.Parameters.Add(status);
                    book.ExecuteNonQuery();

                    Console.WriteLine(status.Value.ToString());

                    // Get the latest booking ID
                    SqlCommand getBookingId = new SqlCommand("SELECT MAX(BookingId) FROM Bookings WHERE CustomerId = @cid", con);
                    getBookingId.Parameters.AddWithValue("@cid", customerId);
                    int bookingId = Convert.ToInt32(getBookingId.ExecuteScalar());

                    // Collect passenger details
                    for (int i = 1; i <= seats; i++)
                    {
                        Console.WriteLine($"\nEnter details for Passenger {i}:");
                        Console.Write("Name: ");
                        string pname = Console.ReadLine();
                        Console.Write("Gender (Male/Female): ");
                        string gender = Console.ReadLine();
                        Console.Write("Age: ");
                        int age = int.Parse(Console.ReadLine());

                        SqlCommand insertPassenger = new SqlCommand("INSERT INTO Passengers (BookingId, Name, Gender, Age) VALUES (@bid, @name, @gender, @age)", con);
                        insertPassenger.Parameters.AddWithValue("@bid", bookingId);
                        insertPassenger.Parameters.AddWithValue("@name", pname);
                        insertPassenger.Parameters.AddWithValue("@gender", gender);
                        insertPassenger.Parameters.AddWithValue("@age", age);
                        insertPassenger.ExecuteNonQuery();
                    }

                    Console.WriteLine("Passenger details saved successfully.");
                }
            }


        public static void CancelBooking()
        {
            using (SqlConnection con = GetConnection())
            {
                Console.Write("Enter Booking ID to cancel: ");
                if (!int.TryParse(Console.ReadLine(), out int bid))
                {
                    Console.WriteLine("Invalid Booking ID.");
                    return;
                }

                // Step 1: Check if booking exists and is not already cancelled
                SqlCommand checkCmd = new SqlCommand("SELECT Train_No, NoOfTickets, Class, TotalCost, IsCancelled FROM Bookings WHERE BookingId = @bid", con);
                checkCmd.Parameters.AddWithValue("@bid", bid);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("Booking not found.");
                    reader.Close();
                    return;
                }

                reader.Read();
                bool isCancelled = Convert.ToBoolean(reader["IsCancelled"]);
                if (isCancelled)
                {
                    Console.WriteLine("Booking is already cancelled.");
                    reader.Close();
                    return;
                }

                int trainNo = Convert.ToInt32(reader["Train_No"]);
                int seats = Convert.ToInt32(reader["NoOfTickets"]);
                string cls = reader["Class"].ToString();
                decimal totalCost = Convert.ToDecimal(reader["TotalCost"]);
                reader.Close();

                // Step 2: Cancel the booking
                SqlCommand cancelCmd = new SqlCommand(@"
            UPDATE Bookings
            SET IsCancelled = 1,
                CancellationDate = GETDATE(),
                RefundAmount = @refund
            WHERE BookingId = @bid", con);
                cancelCmd.Parameters.AddWithValue("@refund", totalCost * 0.5m);
                cancelCmd.Parameters.AddWithValue("@bid", bid);
                cancelCmd.ExecuteNonQuery();

                // Step 3: Update seat availability
                SqlCommand updateSeatsCmd = new SqlCommand(@"
             UPDATE TrainClass
            SET Availability = Availability + @seats
            WHERE Train_No = @tno AND Class = @class", con);
                updateSeatsCmd.Parameters.AddWithValue("@seats", seats);
                updateSeatsCmd.Parameters.AddWithValue("@tno", trainNo);
                updateSeatsCmd.Parameters.AddWithValue("@class", cls);
                updateSeatsCmd.ExecuteNonQuery();

                Console.WriteLine("Ticket cancelled successfully. 50% refund processed.");
            }
        }


        public static void ShowAllTrains()
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("ShowTrains", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();
                    Console.WriteLine("TrainNo | Name | Source | Dest | Class | Seats | Cost");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["Train_No"]} | {dr["Train_Name"]} | {dr["Source"]} | {dr["Destination"]} | {dr["Class"]} | {dr["Availability"]} | {dr["Cost"]}");
                    }
                }
            }





            public static void ShowMyBookings(int customerId)
            {
                using (SqlConnection con = GetConnection())
                {
                    // Step 1: Get all bookings for the user
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings WHERE CustomerId = @cid", con);
                    cmd.Parameters.AddWithValue("@cid", customerId);

                    SqlDataReader dr = cmd.ExecuteReader();

                    
                    var bookings = new List<Dictionary<string, object>>();
                    while (dr.Read())
                    {
                        var booking = new Dictionary<string, object>();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            booking[dr.GetName(i)] = dr.GetValue(i);
                        }
                        bookings.Add(booking);
                    }
                    dr.Close();

                    // Step 2: Display each booking and fetch passengers
                    foreach (var booking in bookings)
                    {
                        int bookingId = Convert.ToInt32(booking["BookingId"]);
                        Console.WriteLine("\n--------------------------------------------------");
                        Console.WriteLine($"Booking ID   : {bookingId}");
                        Console.WriteLine($"Train No     : {booking["Train_No"]}");
                        Console.WriteLine($"Class        : {booking["Class"]}");
                        Console.WriteLine($"Seats        : {booking["NoOfTickets"]}");
                        Console.WriteLine($"Total Cost   : {booking["TotalCost"]}");
                        Console.WriteLine($"Travel Date  : {Convert.ToDateTime(booking["TravelDate"]).ToShortDateString()}");
                        Console.WriteLine($"Cancelled    : {(Convert.ToBoolean(booking["IsCancelled"]) ? "Yes" : "No")}");
                        Console.WriteLine($"Refund       : {booking["RefundAmount"] ?? 0}");

                        // Step 3: Fetch passenger details
                        SqlCommand passengerCmd = new SqlCommand("SELECT Name, Gender, Age FROM Passengers WHERE BookingId = @bid", con);
                        passengerCmd.Parameters.AddWithValue("@bid", bookingId);
                        SqlDataReader pdr = passengerCmd.ExecuteReader();

                        Console.WriteLine("Passengers:");
                        int count = 1;
                        while (pdr.Read())
                        {
                            Console.WriteLine($"  {count++}. {pdr["Name"]} | {pdr["Gender"]} | Age: {pdr["Age"]}");
                        }
                        pdr.Close();
                    }
                }
            }

        }
    }
