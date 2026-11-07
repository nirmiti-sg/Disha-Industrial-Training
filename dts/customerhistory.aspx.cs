using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dts
{
    public partial class customerhistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string custmobile =Request.QueryString["custmobile"];
                if (!string.IsNullOrEmpty(custmobile))
                {
                    BindCustomerHistory(custmobile);
                }
            }
        }

        private void BindCustomerHistory(string custmobile)
        {
            try
            {
                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                    string query ="SELECT consignor, consignee, billing_party, quantity, weight, date, time, pono, partno FROM vrequest  WHERE phoneno = @custmobile  ORDER BY date DESC, time DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@custmobile", custmobile);
                    SqlDataReader dr = cmd.ExecuteReader();
                    gvcustomerhistory.DataSource = dr;
                    gvcustomerhistory.DataBind();
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}
