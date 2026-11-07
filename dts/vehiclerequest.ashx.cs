using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dts
{
    /// <summary>
    /// Summary description for customer_register
    /// </summary>
    public class vehiclerequest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
     
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