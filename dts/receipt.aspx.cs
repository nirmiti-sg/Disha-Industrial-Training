using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace dts
{
    public partial class receipt : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if(!IsPostBack)
            {
                loadreceipt(id);  
            }
        }

        protected void btnprintreceipt_Click(object sender, EventArgs e)
        {
           

        }



        public void loadreceipt(int id)
        {

            int rid = id;
            String cdate = System.DateTime.Now.ToShortDateString();
            dbmanager d = new dbmanager();
            SqlConnection con = d.makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM vrequest WHERE id = @rid";
            //cmd.CommandText = "SELECT * FROM vrequest v, customertbl c WHERE v.id = @rid and c.party_name=v.consignor ";
            cmd.Parameters.Add("@rid",id);
            SqlDataReader dr = cmd.ExecuteReader();
            repreceipt.DataSource = dr;
            repreceipt.DataBind();
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('id received ');", true);
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " crore ";
                number %= 10000000;
            }

            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                string[] unitsMap = { "zero", "one", "two", "three", "four", "five", "six",
                              "seven", "eight", "nine", "ten", "eleven", "twelve",
                              "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
                              "eighteen", "nineteen" };
                string[] tensMap = { "zero", "ten", "twenty", "thirty", "forty", "fifty",
                             "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words.Trim();
        }

    }
}