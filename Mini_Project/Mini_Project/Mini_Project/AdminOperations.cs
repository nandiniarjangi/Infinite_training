using System;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    class AdminOperations
    {
        static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-6ZKZC64\\SQLEXPRESS;database=MiniProject;" + "user id = sa;password = @nandini428647");
            con.Open();
            return con;
        }

        public static bool AdminLogin()
        {
            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
                return false;
            }
        }


        public static void AddTrain()
        {
            using (SqlConnection con = GetConnection())
            {
                Console.Write("Enter Train Number: ");
                int tno = int.Parse(Console.ReadLine());
                Console.Write("Enter Train Name: ");
                string name = Console.ReadLine();
                Console.Write("Source: ");
                string src = Console.ReadLine();
                Console.Write("Destination: ");
                string dest = Console.ReadLine();

                SqlCommand cmd = new SqlCommand("INSERT INTO Trains VALUES (@tno, @name, @src, @dest, 1)", con);
                cmd.Parameters.AddWithValue("@tno", tno);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@src", src);
                cmd.Parameters.AddWithValue("@dest", dest);
                cmd.ExecuteNonQuery();

                string[] classes = { "Sleeper", "2AC", "3AC" };
                foreach (var cls in classes)
                {
                    Console.Write($"Enter availability for {cls}: ");
                    int seats = int.Parse(Console.ReadLine());
                    Console.Write($"Enter cost for {cls}: ");
                    decimal cost = decimal.Parse(Console.ReadLine());

                    SqlCommand ccmd = new SqlCommand("INSERT INTO TrainClass VALUES (@tno, @class, @avail, @cost)", con);
                    ccmd.Parameters.AddWithValue("@tno", tno);
                    ccmd.Parameters.AddWithValue("@class", cls);
                    ccmd.Parameters.AddWithValue("@avail", seats);
                    ccmd.Parameters.AddWithValue("@cost", cost);
                    ccmd.ExecuteNonQuery();
                }

                Console.WriteLine("Train and classes added successfully.");
            }
        }

        public static void UpdateTrain()
        {
            using (SqlConnection con = GetConnection())
            {
                Console.Write("Enter Train Number to update: ");
                int tno = int.Parse(Console.ReadLine());

                Console.WriteLine("1. Train Name");
                Console.WriteLine("2. Source");
                Console.WriteLine("3. Destination");
                Console.Write("Choose attribute to update: ");
                int attr = int.Parse(Console.ReadLine());

                string column = attr == 1 ? "Train_Name" : attr == 2 ? "Source" : "Destination";
                Console.Write($"Enter new value for {column}: ");
                string value = Console.ReadLine();

                SqlCommand cmd = new SqlCommand($"UPDATE Trains SET {column} = @val WHERE Train_No = @tno", con);
                cmd.Parameters.AddWithValue("@val", value);
                cmd.Parameters.AddWithValue("@tno", tno);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Train updated.");
            }
        }

        public static void DeleteTrain()
        {
            using (SqlConnection con = GetConnection())
            {
                Console.Write("Enter Train Number to delete: ");
                int tno = int.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand("UPDATE Trains SET IsActive = 0 WHERE Train_No = @tno", con);
                cmd.Parameters.AddWithValue("@tno", tno);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Train marked as inactive.");
            }
        }
    }
}

