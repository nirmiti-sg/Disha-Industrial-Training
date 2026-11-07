using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace dts
{
    public partial class driverhistory : System.Web.UI.Page
    {
        String mobile,vnum;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                mobile = Request.QueryString["mobile"].ToString();
                dbmanager d = new dbmanager();
                vnum = d.getvehiclenumbymobile(mobile);
                Session["vnum"] = vnum;
                loadnewrequests(vnum);
            }

        }

       

        public void loadnewrequests(String vnum)
        {
            dbmanager d = new dbmanager();
            SqlDataReader dr=d.driverhistory(vnum);
            gvdriverhistory.DataSource = dr;
            gvdriverhistory.DataBind();

            
        }

        protected void gvdriverhistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "acc")
            {
                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update assigned_driver set status='accepted' where assignid=@id";
                cmd.Parameters.Add("@id", id);
                cmd.ExecuteNonQuery();
                loadnewrequests(Session["vnum"].ToString());
            }
            if (e.CommandName == "comp")
            {
                dbmanager d = new dbmanager();
                SqlConnection con = d.makeconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update assigned_driver set status='completed' where assignid=@id";
                cmd.Parameters.Add("@id", id);
                cmd.ExecuteNonQuery();
                loadnewrequests(Session["vnum"].ToString());

            }
        }

        protected void gvdriverhistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "status")?.ToString();

                Button btnAccept = (Button)e.Row.FindControl("btnAccept");
                Button btnCompleted = (Button)e.Row.FindControl("btnCompleted");

                if (status == "")
                {

                    if (btnCompleted != null) btnCompleted.Visible = false;
                }
                else if (status.ToLower() == "accepted")
                {

                    if (btnAccept != null) btnAccept.Visible = false;
                }
                else if (status.ToLower() == "completed")
                {
                    if (btnCompleted != null) btnCompleted.Visible = false;
                    if (btnAccept != null) btnAccept.Visible = false;
                }
            }
        }
    }
}