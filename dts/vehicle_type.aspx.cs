using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace dts
{
    public partial class vehicle_type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {  
                loadvehicletypes();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from vehicletype where vtype=@vt";
            cmd.Parameters.Add("@vt", txttype.Text.Trim());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                txttype.Text = "";
                Response.Write("<script>alert('Vehicle type already exist')</script>");
            }
            else
            {
                dr.Close();
                cmd.Dispose();

                cmd.CommandText = "insert into vehicletype(vtype) values(@vt)";
                cmd.ExecuteNonQuery();
                txttype.Text = "";
                loadvehicletypes();
            }
        }


        public void loadvehicletypes()
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from vehicletype";
            SqlDataReader dr = cmd.ExecuteReader();
            gvtype.DataSource = dr;
            gvtype.DataBind();
        }

        protected void gvtype_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "dele")
            {
                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from vehicletype where vid=@vid";
                cmd.Parameters.AddWithValue("@vid",id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Vehicle type Deleted')</script>");
                loadvehicletypes();
            }

        }
    }
}