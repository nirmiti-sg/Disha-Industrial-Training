using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace dts
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                addnewcustomer();
            }
           
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from customertbl where party_name=@pn";
          
            cmd.Parameters.Add("@pn", txtpname.Text.Trim());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                txtpname.Text = "";
                Response.Write("<script>alert('party name already exist')</script>");
            }
            else
            {
                dr.Close();
                cmd.Dispose();

                cmd.CommandText = "insert into customertbl(party_name,address,contact_person_name,phone_no,pan_no,gst_no,password) values(@ptn,@add,@cpn,@phoneno,@panno,@gstno,@pass)";
                cmd.Parameters.Add("@ptn", txtpname.Text.Trim());
                cmd.Parameters.Add("@add", txtaddress.Text.Trim());
                cmd.Parameters.Add("@cpn", txtconperson.Text.Trim());
                cmd.Parameters.Add("@phoneno", txtphoneno.Text.Trim());
                cmd.Parameters.Add("@panno", txtpanno.Text.Trim());
                cmd.Parameters.Add("@gstno", txtgstno.Text.Trim());
                cmd.Parameters.Add("@pass", txtpass.Text.Trim());

                cmd.ExecuteNonQuery();
                txtpname.Text = "";
                txtaddress.Text = "";
                txtconperson.Text = "";
                txtphoneno.Text = "";
                txtpanno.Text = "";
                txtgstno.Text = "";
                addnewcustomer();
            }
        }


        public void addnewcustomer()
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from customertbl";
            SqlDataReader dr = cmd.ExecuteReader();
              gvname.DataSource = dr;
            gvname.DataBind();
        }

         protected void gcustomer_RowCommand(object sender, GridViewCommandEventArgs e)
         {
             int id = Convert.ToInt32(e.CommandArgument);
             if (e.CommandName == "dele")
             {
                 dbmanager d = new dbmanager();
                 SqlConnection con = d.makeconnection();
                 con.Open();
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = con;
                 cmd.CommandText = "delete from customertbl where id=@id";
                 cmd.Parameters.AddWithValue("@id", id);
                 cmd.ExecuteNonQuery();
                 Response.Write("<script>alert('record Deleted')</script>");
                addnewcustomer();
             }


            if (e.CommandName == "act")
            {

                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update customertbl set flag=1 where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Activated')</script>");
                addnewcustomer();

            }


            if (e.CommandName == "deact")
            {

                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update customertbl set flag=0 where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Activated')</script>");
                addnewcustomer();
            }

        }
    }
}