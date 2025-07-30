using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source = ICS-LT-6ZKZC64\\SQLEXPRESS; database = assessments; " + "user id = sa; password = @nandini428647";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("insert_employee_details", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                cmd.Parameters.AddWithValue("@name", "nandini arjangi");
                cmd.Parameters.AddWithValue("@givensalary", 50000);
                cmd.Parameters.AddWithValue("@gender", "f");

                // Output parameter
                SqlParameter outputParam = new SqlParameter("@generatedempid", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                int generatedEmpId = (int)cmd.Parameters["@generatedempid"].Value;
                Console.WriteLine("Generated EmpId: " + generatedEmpId);

                // Optional: Fetch the inserted salary
                string query = "select salary from employee_details where empid = @empid";
                using (SqlCommand salaryCmd = new SqlCommand(query, conn))
                {
                    salaryCmd.Parameters.AddWithValue("@empid", generatedEmpId);
                    object salary = salaryCmd.ExecuteScalar();
                    Console.WriteLine("Calculated Salary: " + salary);
                }
            }
            Console.ReadLine();
        }
    }
}
