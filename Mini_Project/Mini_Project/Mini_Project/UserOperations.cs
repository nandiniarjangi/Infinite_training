using System;
using System.Data;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    class UserOperations
    {
        static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-6ZKZC64\\SQLEXPRESS;database=MiniProject;" + "user id = sa;password = @nandini428647");
            con.Open();
            return con;
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

                SqlCommand cmd = new SqlCommand("INSERT INTO Customers (CustName, Phone, MailId) OUTPUT INSERTED.CustId VALUES (@name, @phone, @mail)", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@mail", mail);

                int id = (int)cmd.ExecuteScalar();
                Console.WriteLine($"Welcome!!!,Your Registration successful. Your Customer ID: {id}");
            }
        }
       


        public static void BookTrainTicket()
        {
            using (SqlConnection con = GetConnection())
            {
                Console.Write("Enter Customer ID: ");
                int cid = int.Parse(Console.ReadLine());
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
                    Console.WriteLine($"{dr["Train_No"]} | {dr["Train_Name"]} | {dr["Class"]} | {dr["Availability"]} | ₹{dr["Cost"]}");
                }
                dr.Close();

                Console.Write("Enter Train No: ");
                int tno = int.Parse(Console.ReadLine());
                Console.Write("Enter Class: ");
                string cls = Console.ReadLine();
                Console.Write("Enter Seats: ");
                int seats = int.Parse(Console.ReadLine());
                Console.Write("Enter Travel Date (yyyy-mm-dd): ");
                DateTime travelDate = DateTime.Parse(Console.ReadLine());

                SqlCommand book = new SqlCommand("BookTickets", con);
                book.CommandType = CommandType.StoredProcedure;
                book.Parameters.AddWithValue("@tno", tno);
                book.Parameters.AddWithValue("@cid", cid);
                book.Parameters.AddWithValue("@tclass", cls);
                book.Parameters.AddWithValue("@seats", seats);
                book.Parameters.AddWithValue("@travelDate", travelDate);

                SqlParameter status = new SqlParameter("@status", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output };
                book.Parameters.Add(status);
                book.ExecuteNonQuery();

                Console.WriteLine(status.Value.ToString());
            }
        }

        public static void CancelBooking()
        {
            using (SqlConnection con = GetConnection())
            {
                Console.Write("Enter Booking ID to cancel: ");
                int bid = int.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand("CancelBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bid", bid);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Ticket cancelled. 50% refund processed.");
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
                    Console.WriteLine($"{dr["Train_No"]} | {dr["Train_Name"]} | {dr["Source"]} | {dr["Destination"]} | {dr["Class"]} | {dr["Availability"]} | ₹{dr["Cost"]}");
                }
            }
        }

        public static void ShowMyBookings()
        {
            using (SqlConnection con = GetConnection())
            {
                Console.Write("Enter Customer ID: ");
                int cid = int.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings WHERE CustomerId = @cid", con);
                cmd.Parameters.AddWithValue("@cid", cid);

                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("BookingID | Train | Class | Seats | Cost | Travel Date | Cancelled | Refund");

                while (dr.Read())
                {
                    Console.WriteLine($"{dr["BookingId"]} | {dr["Train_No"]} | {dr["Class"]} | {dr["NoOfTickets"]} | ₹{dr["TotalCost"]} | {Convert.ToDateTime(dr["TravelDate"]).ToShortDateString()} | {(Convert.ToBoolean(dr["IsCancelled"]) ? "Yes" : "No")} | ₹{dr["RefundAmount"] ?? 0}");
                }
            }
        }
    }
}