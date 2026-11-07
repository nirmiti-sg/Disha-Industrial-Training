using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace dts
{
    public partial class home : System.Web.UI.Page
    {
        private object lblmessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                newvrequest();
                requestrecord();
            }
            

        }

        public void newvrequest()
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from vrequest where ack_status is null";
            SqlDataReader dr = cmd.ExecuteReader();
            gvdata.DataSource = dr;
            gvdata.DataBind();
        }


        protected void gvrequeast_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "dele")
            {
                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from vrequest where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('request Deleted')</script>");
                newvrequest();
            }
            if (e.CommandName == "accept")
            {
                panelupdate.Visible = true;
                txtrid.Text = id.ToString();
            }

            if (e.CommandName == "assigndv")
            {
                Response.Redirect("assigndriver.aspx?id="+id);
            }

         

        }


        public void btnupdate_Click(object sender, EventArgs e)
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update vrequest set booking=@booking, delivery=@delivery, gst_no=@gst_no, pay_type=@pay_type, vehicle_no=@vehicle_no, lr_total=@lr_total, ack_status=@ack_status, pod_uploded_status=@pod_uploded_status where id=@id";
                cmd.Parameters.Add("@booking", txtrbooking.Text);
                cmd.Parameters.Add("@delivery", txtrdelivery.Text);
                cmd.Parameters.Add("@gst_no", txtrgstno.Text);
                cmd.Parameters.Add("@pay_type", txtrpaytype.Text);
                cmd.Parameters.Add("@vehicle_no", txtrvno.Text);
                cmd.Parameters.Add("@lr_total", txtrlrtotal.Text);
                cmd.Parameters.Add("@ack_status", txtrackstatus.Text);
                cmd.Parameters.Add("@pod_uploded_status", txtrpoduplodedstatus.Text);
                cmd.Parameters.Add("@id", txtrid.Text);
                cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record updated ');", true);
            txtrbooking.Text=" ";
            txtrdelivery.Text=" ";
            txtrgstno.Text=" ";
            txtrpaytype.Text=" ";
            txtrvno.Text=" ";
            txtrlrtotal.Text=" ";
            txtrackstatus.Text=" ";
            txtrpoduplodedstatus.Text=" ";
            txtrid.Text=" ";

            panelupdate.Visible = false;
            newvrequest();
        }


        public void requestrecord()
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from vrequest where booking is not null order by id desc";
            SqlDataReader dr = cmd.ExecuteReader();
            GridView2.DataSource = dr;
            GridView2.DataBind();
        }



        public void loadvehicles()
        {
            ddrvehiclenumber.Items.Clear();
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from drivertbl";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddrvehiclenumber.Items.Add(dr["vehicleno"].ToString());
            }


           String assigneddate = System.DateTime.Now.ToShortDateString();
        
        }

        public void btnassign_dv(object sender, EventArgs e)
        {
            String assigneddate = System.DateTime.Now.ToShortDateString();
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into assigned_driver(requestid,vehicle_no,date) values(@requestid,@vehicle_no,@date)";
            cmd.Parameters.Add("@requestid", txtid.Text);
            cmd.Parameters.Add("@vehicle_no", ddrvehiclenumber.Text);
            cmd.Parameters.Add("@date", assigneddate);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record inserted');", true);
            txtid.Text = "";
            panel2.Visible = false;
        }




        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);


            if (e.CommandName == "printrec")
            {
                Response.Redirect("receipt.aspx?id=" + id);
            }

        }
    }
}