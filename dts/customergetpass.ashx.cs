using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dts
{
    
    public class customergetpass : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            String mobile = context.Request.QueryString["mobile"].ToString();
            dbmanager d = new dbmanager();
            String result = d.getcustomerpass(mobile);


            context.Response.Write(result);
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