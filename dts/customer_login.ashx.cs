using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dts
{
    /// <summary>
    /// Summary description for customer_login
    /// </summary>
    public class customer_login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String cphone = context.Request.QueryString["cphone"].ToString();
            String pass = context.Request.QueryString["cpass"].ToString();
            dbmanager d = new dbmanager();
            int res = d.custlogincheck(cphone, pass);
            if (res == 1)
            {
                context.Response.Write("Success");
            }
            else if (res == 0)
            {
                context.Response.Write("Invalid userid/password");
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