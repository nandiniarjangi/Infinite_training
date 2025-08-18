using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EB_Prj
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand(@"SELECT COUNT(1) FROM dbo.AdminUsers WHERE Username=@u AND Password=@p", con))
            {
                cmd.Parameters.AddWithValue("@u", txtUser.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtPass.Text.Trim());

                con.Open();
                int ok = (int)cmd.ExecuteScalar();
                if (ok == 1)
                {
                    Session["Admin"] = txtUser.Text.Trim();
                    Response.Redirect(ConfigurationManager.AppSettings["HomePage"]);
                }
                else
                {
                    lblMsg.Text = "Invalid username or password.";
                }
            }
        }
    }
}