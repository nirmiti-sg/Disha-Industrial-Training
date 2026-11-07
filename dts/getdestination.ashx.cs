using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace dts
{
    /// <summary>
    /// Summary description for getdestination
    /// </summary>
    public class getdestination : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            List<String> result = new List<string>();
            dbmanager d = new dbmanager();
            result = d.getdestinationlocation();            
            
            String json = JsonConvert.SerializeObject(result, Formatting.Indented);
            context.Response.Write(json);
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