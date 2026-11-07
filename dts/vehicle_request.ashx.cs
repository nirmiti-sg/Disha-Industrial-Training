using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dts
{
    /// <summary>
    /// Summary description for vehicle_request
    /// </summary>

 /*   public class vehicle_request : IHttpHandler, 
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";



            string vtype, source, destination, billingp, quantity, weight, date, time, pono, partno;

 
            byte[] b = dbmanager.ReadAllStream(context.Request.InputStream);
            string str = System.Text.Encoding.UTF8.GetString(b);

            registor r = Newtonsoft.Json.JsonConvert.DeserializeObject<registor>(str);

            vtype = r.vtype;
            source = r.source;
            destination = r.destination;
            billingp = r.billingp;
            quantity = r.quantity;
            weight = r.weight;
            date = r.date;
            time = r.time;
            pono = r.pono;
            partno = r.partno;

            string phoneno = context.Session["custmobile"]?.ToString();

            dbmanager d1 = new dbmanager();
            int res = d1.requestvehicle(vtype, source, destination, billingp, quantity, weight, date, time, pono, partno, phoneno);


            if (res == 1)
                context.Response.Write("Success");
            else
                context.Response.Write("Failed");
        }

        */
        public class vehicle_request : IHttpHandler
        {

            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "text/plain";

               // String phoneno = context.Session["custmobile"]?.ToString();
                String vtype, source, destination, billingp, quantity, weight, date, time, pono, partno,custmobile;


                byte[] b = dbmanager.ReadAllStream(context.Request.InputStream);
                String str = System.Text.Encoding.UTF8.GetString(b);

                registor r = Newtonsoft.Json.JsonConvert.DeserializeObject<registor>(str);

                vtype = r.vtype;
                source = r.source;
                destination = r.destination;
                billingp = r.billingp;
                quantity = r.quantity;
                weight = r.weight;
                date = r.date;
                time = r.time;
                pono = r.pono;
                partno = r.partno;
                custmobile = r.custmobile;
         

            dbmanager d1 = new dbmanager();
                int res = d1.requestvehicle(vtype, source, destination, billingp, quantity, weight, date, time, pono, partno, custmobile);
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