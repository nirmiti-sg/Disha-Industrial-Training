using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dts
{
    /// <summary>
    /// Summary description for getpartylocation
    /// </summary>
    public class getpartylocation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String mobile = context.Request.QueryString["mobile"].ToString();
            dbmanager d = new dbmanager();
            String result = d.getpartylocation(mobile);            
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