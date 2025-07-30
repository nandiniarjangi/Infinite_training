using System;
using System.Data;
using System.Data.SqlClient;

class Update_sal
{
    static void Main()
    {
        string connectionString = "Data Source=ICS-LT-6ZKZC64\\SQLEXPRESS;database=assessments;" + "user id = sa;password = @nandini428647"; 
        int empId = 2; 

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

           
            using (SqlCommand cmd = new SqlCommand("update_employee_salary", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empid", empId);

                SqlParameter outputSalary = new SqlParameter("@updatedsalary", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputSalary);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Updated Salary: " + outputSalary.Value);
            }

            
            string query = "select empid, name, salary, gender from employee_details where empid = @empid";
            using (SqlCommand detailCmd = new SqlCommand(query, conn))
            {
                detailCmd.Parameters.AddWithValue("@empid", empId);

                using (SqlDataReader reader = detailCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("Employee Details:");
                        Console.WriteLine("EmpId: " + reader["empid"]);
                        Console.WriteLine("Name: " + reader["name"]);
                        Console.WriteLine("Salary: " + reader["salary"]);
                        Console.WriteLine("Gender: " + reader["gender"]);
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }
                }
                Console.ReadLine();
            }
        }
    }
}

