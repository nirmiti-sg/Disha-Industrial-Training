using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dts
{
    /// <summary>
    /// Summary description for driver_login
    /// </summary>
    public class driver_login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {


            context.Response.ContentType = "text/plain";
            String dphone = context.Request.QueryString["dphone"].ToString();
            String pass = context.Request.QueryString["dpass"].ToString();
            dbmanager d = new dbmanager();
            int res = d.driverlogincheck(dphone,pass);
            if (res == 1)
            {
                context.Response.Write("Success");
            }
            else if (res == 0)
            {
                context.Response.Write("Failed");
            }
            else
            {
                context.Response.Write("Internal Error Occured, try again Later");
            }

            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}