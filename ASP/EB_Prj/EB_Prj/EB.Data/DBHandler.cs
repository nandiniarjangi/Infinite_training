using System.Configuration;
using System.Data.SqlClient;

namespace EB.Data
{
    public class DBHandler
    {
        

        public SqlConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
