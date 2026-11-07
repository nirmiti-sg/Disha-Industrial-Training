using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace dts
{
    public partial class assigndriver : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
              String vt= getvtype(id);
                loaddriversbyvtype(vt);
                viewassigneddriver();
            }

        }




        public String getvtype(int requestid)
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from vrequest where id=@id";
            cmd.Parameters.Add("@id", requestid);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            String vtype = dr["vehicle_type"].ToString();
            return vtype;
        }


        public void loaddriversbyvtype(String vtype)
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from drivertbl where vehicletype=@vt and status=1";
            cmd.Parameters.Add("@vt", vtype);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                drddriver.Items.Add(dr["vehicleno"].ToString());
            }


        }

        protected void btnassigndriver_Click(object sender, EventArgs e)
        {
            int rid = id;
            String cdate = System.DateTime.Now.ToShortDateString();
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into assigned_driver(requestid,vehicle_no,date) values(@rid,@vno,@date)";
            cmd.Parameters.Add("@rid", rid);
            cmd.Parameters.Add("@vno", drddriver.SelectedValue);
            cmd.Parameters.Add("@date", cdate);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record inserted');", true);
        }

        public void viewassigneddriver()
        {
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select a.requestid,d.drivername,d.vehicletype,a.vehicle_no,a.date from assigned_driver a, drivertbl d where a.vehicle_no=d.vehicleno";
            SqlDataReader dr = cmd.ExecuteReader();
            gassigndv.DataSource = dr;
            gassigndv.DataBind();

        }

    }
}