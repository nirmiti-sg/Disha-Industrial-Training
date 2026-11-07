using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dts
{
    /// <summary>
    /// Summary description for customer_register
    /// </summary>
    public class customer_register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            String pname, address, cname, pno, panno, gstno, pass;

            byte[] b = dbmanager.ReadAllStream(context.Request.InputStream);
            String str = System.Text.Encoding.UTF8.GetString(b);

            customeruser c = Newtonsoft.Json.JsonConvert.DeserializeObject<customeruser>(str);

            pname = c.pname;
            address = c.address;
            cname = c.cname;
            pno = c.phoneno;
            panno = c.panno;
            gstno = c.gstno;
            pass = c.pass;

            //pname = "thermax";
            //address = "solapur";
            //cname = "Nirmiti";
            //pno = "9226984289";
            //panno = "XYZ1663657";
            //gstno = "hvqyeigbei89";
            //pass = "pass123";





            dbmanager d1 = new dbmanager();
            int res = d1.customerreg(pname, address, cname, pno, panno, gstno, pass);
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