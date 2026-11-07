using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace dts
{
    public partial class driver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                addnewdriver();
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
            cmd.CommandText = "select * from drivertbl where drivername=@dn";

            cmd.Parameters.Add("@dn", txtname.Text.Trim());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                txtname.Text = "";
                Response.Write("<script>alert('driver already exist')</script>");
            }
            else
            {
                dr.Close();
                cmd.Dispose();

                cmd.CommandText = "insert into drivertbl(drivername,mobilenumber,emailid,address,password,vehicleno,vehicletype) values(@drn,@mn,@eid,@add,@pass,@vno,@vtype)";
                cmd.Parameters.Add("@drn", txtname.Text.Trim());
                cmd.Parameters.Add("@mn", txtmono.Text.Trim());
                cmd.Parameters.Add("@eid", txteid.Text.Trim());
                cmd.Parameters.Add("@add", txtaddress.Text.Trim());
                cmd.Parameters.Add("@pass", txtpass.Text.Trim());
                cmd.Parameters.Add("@vno", txtvno.Text.Trim());
                cmd.Parameters.Add("@vtype", drdtype.Text.Trim());

                cmd.ExecuteNonQuery();
                txtname.Text = "";
                txtmono.Text = "";
                txteid.Text = "";
                txtaddress.Text = "";
                txtpass.Text = "";
                txtvno.Text = "";
                addnewdriver();
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
            while (dr.Read())
            {
                drdtype.Items.Add(dr["vtype"].ToString());
            }


        }


        public void addnewdriver()
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from drivertbl";
            SqlDataReader dr = cmd.ExecuteReader();
            gdname.DataSource = dr;
            gdname.DataBind();
        }

        protected void gdriver_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "dele")
            {
                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from drivertbl where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('record Deleted')</script>");
                addnewdriver();
            }

            if (e.CommandName == "act")
            {

                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update drivertbl set flag=1 where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Activated')</script>");
                addnewdriver();

            }

            if (e.CommandName == "deact")
            {

                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update drivertbl set flag=0 where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Activated')</script>");
                addnewdriver();
            }
        }
    }
}