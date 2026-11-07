using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace dts
{
    public partial class admin_signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadadminlist();
            }
          
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();

                // 🔎 Check if admin already exists
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM admintbl WHERE name=@name", con);
                checkCmd.Parameters.AddWithValue("@name", txtusername.Text.Trim());
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Admin already exists!');", true);
                    return;
                }

                // ✅ Insert new admin
                SqlCommand cmd = new SqlCommand("INSERT INTO admintbl(name, phone_no, email_id, address, [password]) VALUES(@aname,@pn,@mail,@add,@pass)", con);
                cmd.Parameters.AddWithValue("@aname", txtusername.Text.Trim());
                cmd.Parameters.AddWithValue("@pn", txtphoneno.Text.Trim());
                cmd.Parameters.AddWithValue("@mail", txtmail.Text.Trim());
                cmd.Parameters.AddWithValue("@add", txtadd.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", txtpass.Text.Trim());

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    clearfields();   // ✅ Clear textboxes
                    loadadminlist(); // ✅ Reload grid

                    // ✅ Show success + redirect
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertRedirect",
                        "alert('Admin added successfully!'); window.location='home.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to add admin.');", true);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: " + ex.Message.Replace("'", "\\'") + "');", true);
            }
        }



        /*    protected void btnadd_Click(object sender, EventArgs e)
            {
                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from admintbl where name=@name";

                cmd.Parameters.Add("@name", txtusername.Text.Trim());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    txtusername.Text = "";
                    Response.Write("<script>alert('admin already exist')</script>");
                }
                else
                {
                    dr.Close();
                    cmd.Dispose();

                    cmd = new SqlCommand( "insert into admintbl(name,phone_no,email_id,address,password) values(@aname,@pn,@mail,@add,@pass)",con);
                    cmd.Parameters.Add("@aname", txtusername.Text.Trim());
                    cmd.Parameters.Add("@pn", txtphoneno.Text.Trim());
                    cmd.Parameters.Add("@mail", txtmail.Text.Trim());
                    cmd.Parameters.Add("@add", txtadd.Text.Trim());
                    cmd.Parameters.Add("@pass", txtpass.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Admin added successfully!');</script>");
                    clearfields();
                    loadadminlist();
                }
            }
            */

        public void loadadminlist()
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from admintbl";
            SqlDataReader dr = cmd.ExecuteReader();
            ganame.DataSource = dr;
            ganame.DataBind();
        }

        private void clearfields()
        {
            txtusername.Text = "";
            txtphoneno.Text = "";
            txtmail.Text = "";
            txtadd.Text = "";
            txtpass.Text = "";
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            clearfields();   
        }

    }
}