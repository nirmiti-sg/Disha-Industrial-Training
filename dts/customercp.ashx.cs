using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dts
{
    /// <summary>
    /// Summary description for customercp
    /// </summary>
    public class customercp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String mobile = context.Request.QueryString["mn"].ToString();
            String oldpass = context.Request.QueryString["op"].ToString();
            String newpass = context.Request.QueryString["np"].ToString();
            dbmanager d = new dbmanager();
            int result = d.customerchangepass(mobile, oldpass, newpass);
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