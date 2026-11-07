using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dts
{
    /// <summary>
    /// Summary description for driver_register
    /// </summary>
    public class driver_register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String name, mobile, email, address, pass, vehicleno, vehicletype;


            byte[] b = dbmanager.ReadAllStream(context.Request.InputStream);
            String str = System.Text.Encoding.UTF8.GetString(b);

            driveruser d = Newtonsoft.Json.JsonConvert.DeserializeObject<driveruser>(str);

            
            name = d.dname;
            mobile = d.mobile;
            address = d.address;
            pass = d.pass;
            vehicleno = d.vnum;
            vehicletype = d.vtype;
            email = d.email;




            dbmanager d1 = new dbmanager();
            int res=d1.driverreg(name, mobile, email, address, vehicleno, vehicletype,pass);
            if (res == 1)
            {
                context.Response.Write("Success");
            }
            else if (res == 0)
            {
                context.Response.Write("Failed");
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