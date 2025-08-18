using System;
using System.Linq;
using EB.Domain;
using System.Collections.Generic;

namespace EB_Prj
{
    public partial class Bills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void btnSetCount_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCount.Text, out int count) || count <= 0)
            {
                lblCountMsg.Text = "Enter a valid positive number.";
                return;
            }
            Session["Remaining"] = count;
            Session["Added"] = 0;
            pnlEntry.Visible = true;
            pnlHowMany.Visible = false;
            lblIndex.Text = $"#{(int)Session["Added"] + 1} of {count}";
        }

        protected void btnAddOne_OnClick(object sender, EventArgs e)
        {
            lblAddMsg.Text = "";
            var validator = new BillValidator();
            if (!int.TryParse(txtUnits.Text, out int units))
            {
                lblAddMsg.Text = "Units must be a number.";
                return;
            }

            // Validate units (Validation 2)
            var msg = validator.ValidateUnitsConsumed(units);
            if (msg != null)
            {
                lblAddMsg.Text = msg; // “Given units is invalid”
                return;
            }

            try
            {
                // Construct EB object (Validation 1 happens in setter)
                var eb = new ElectricityBill
                {
                    ConsumerNumber = txtCNo.Text,
                    ConsumerName = txtCName.Text,
                    UnitsConsumed = units
                };

                // Calculate bill and store (Req. #1 and #2)
                var board = new ElectricityBoard();
                board.CalculateBill(eb);
                board.AddBill(eb);

                // Show per-line output like sample
                lblAddMsg.ForeColor = System.Drawing.Color.Green;
                lblAddMsg.Text = $"{eb.ConsumerNumber} {eb.ConsumerName} {eb.UnitsConsumed} Bill Amount : {eb.BillAmount:N0}";

                // Step counter
                int remaining = (int)Session["Remaining"];
                int added = (int)Session["Added"] + 1;
                Session["Added"] = added;
                remaining--;
                Session["Remaining"] = remaining;

                if (remaining > 0)
                {
                    lblIndex.Text = $"#{added + 1} of {(int)Session["Added"] + remaining}";
                    txtCNo.Text = ""; txtCName.Text = ""; txtUnits.Text = "";
                    txtCNo.Focus();
                }
                else
                {
                    pnlEntry.Visible = false;
                    pnlRetrieve.Visible = true;
                }
            }
            catch (FormatException ex)
            {
                // Must display message contained in the exception object itself (“Invalid Consumer Number”)
                lblAddMsg.Text = ex.Message;
            }
        }

        protected void BtnFetch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLastN.Text, out int n) || n <= 0)
            {
                lblAddMsg.Text = "Enter a valid number for N.";
                return;
            }

            var board = new ElectricityBoard();
            var bills = board.Generate_N_BillDetails(n);

            gvBills.DataSource = bills;
            gvBills.DataBind();
            gvBills.Visible = true;

            rptText.DataSource = bills.Select(x => new { x.ConsumerName, x.BillAmount });
            rptText.DataBind();
            rptText.Visible = true;
        }
    }
        

}
