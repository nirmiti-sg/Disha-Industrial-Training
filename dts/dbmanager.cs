using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;

namespace dts
{
    public class dbmanager
    {

        public SqlConnection makeconnection()
        {
            SqlConnection con = new SqlConnection("Data Source=zwin02.securehostdns.com,1234;Initial Catalog=dishdb;Persist Security Info=True;User ID=user;Password=pass");
            return con;
        }


        public string getvehiclenumbymobile(String mobile)
        {
            SqlConnection con = makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from drivertbl where mobilenumber=@mobile";
            cmd.Parameters.Add("@mobile", mobile);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            String vnum = dr["vehicleno"].ToString();
            return vnum;

        }

        public SqlDataReader customerhistory(String cnum)
        {
            SqlConnection con = makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from vrequest v,customertbl c where v.phoneno=c.phone.no";
            cmd.Parameters.Add("@cnum", cnum);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        public SqlDataReader driverhistory(String vnum)
        {
            SqlConnection con = makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from vrequest v,assigned_driver a where a.requestid=v.id and a.vehicle_no=@vnum";
            cmd.Parameters.Add("@vnum",vnum);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public int customerreg(String pname, String address, String cname, String phoneno, String panno, String gstno, String pass)
        {
            SqlConnection con = makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from customertbl where party_name=@pn";
            cmd.Parameters.Add("@pn", pname);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return 0;
            }
            else
            {
                dr.Close();
                cmd.Dispose();

                cmd.CommandText = "insert into customertbl(party_name,address,contact_person_name,phone_no,pan_no,gst_no,password,flag) values(@pn,@add,@cn,@pno,@panno,@gstno,@pass,@flag)";
                cmd.Parameters.Add("@add", address);
                cmd.Parameters.Add("@cn", cname);
                cmd.Parameters.Add("@pno", phoneno);
                cmd.Parameters.Add("@panno", panno);
                cmd.Parameters.Add("@gstno", gstno);
                cmd.Parameters.Add("@pass", pass);
                cmd.Parameters.Add("@flag", 0);
                cmd.ExecuteNonQuery();
                return 1;
            }
        }




        public int driverreg(String dname, String mobile, String email, String address, String vnum, String vtype, String pass)
        {
            SqlConnection con = makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from drivertbl where drivername=@dn";
            cmd.Parameters.Add("@dn", dname);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return 0;
            }
            else
            {
                dr.Close();
                cmd.Dispose();

                cmd.CommandText = "insert into drivertbl(drivername,mobilenumber,emailid,address,password,vehicleno,vehicletype,flag) values(@dn,@mn,@eid,@add,@pass,@vno,@vtype,@flag)";
                cmd.Parameters.Add("@mn", mobile);
                cmd.Parameters.Add("@eid", email);
                cmd.Parameters.Add("@add", address);
                cmd.Parameters.Add("@pass", pass);
                cmd.Parameters.Add("@vno", vnum);
                cmd.Parameters.Add("@vtype", vtype);
                cmd.Parameters.Add("@flag", 0);
                cmd.ExecuteNonQuery();
                return 1;
            }
        }

        public int requestvehicle(String vtype, String source, String destination, String billingp, String quantity, String weight, String date, String time,String pono, String partno, String phoneno)
        {
            SqlConnection con = makeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
      
            cmd.CommandText = "insert into vrequest(vehicle_type,consignor,consignee,billing_party,quantity,weight,date,time,pono,partno,phoneno) values(@vt,@sor,@dest,@bp,@qty,@weig,@date,@time,@pono,@part,@phone)";
            cmd.Parameters.Add("@vt", vtype);
            cmd.Parameters.Add("@sor", source);
                cmd.Parameters.Add("@dest", destination);
                cmd.Parameters.Add("@bp", billingp);
                cmd.Parameters.Add("@qty", quantity);
                cmd.Parameters.Add("@weig", weight);
                cmd.Parameters.Add("@date", date);
                cmd.Parameters.Add("@time", time);
                cmd.Parameters.Add("@pono", pono);
                cmd.Parameters.Add("@part", partno);
            cmd.Parameters.Add("@phone", phoneno);
            cmd.ExecuteNonQuery();
                return 1;
            
        }


        public int custlogincheck(String cmobile, String cpass)
        {
            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from customertbl where phone_no=@cphone and password=@cpass and flag=1";
                    cmd.Parameters.AddWithValue("@cphone", cmobile);
                    cmd.Parameters.AddWithValue("@cpass", cpass);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ec1)
                {
                    return -1;
                }
            }
            catch(Exception ec2)
            { 
                return -2;
            }
        }


        public List<String>getdestinationlocation()
        {

            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from customertbl";
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> result = new List<string>();
                    while(dr.Read())
                    {
                        result.Add(dr["party_name"].ToString());
                    }
                    return result;

                }
                catch (Exception e1)
                {
                    return null;
                }
            }
            catch (Exception e2)
            {
                return null;
            }
        }
        public List<String> getvehicletype()
        {

            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from vehicletype";
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> result = new List<string>();
                    while (dr.Read())
                    {
                        result.Add(dr["vtype"].ToString());
                    }
                    return result;

                }
                catch (Exception e1)
                {
                    return null;
                }
            }
            catch (Exception e2)
            {
                return null;
            }
        }






        public String getpartylocation(String mobile)
        {

            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from customertbl where phone_no=@dphone";
                    cmd.Parameters.AddWithValue("@dphone", mobile);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        String source = dr["party_name"].ToString();
                        return source;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e1)
                {
                    return "internaleerror";
                }
            }
            catch (Exception e2)
            {
                return "connection";
            }
         }


        public int driverchangepass(String mobile, String oldpass, String newpass)
        {

            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from drivertbl where mobilenumber=@dphone and password=@dpass";
                    cmd.Parameters.AddWithValue("@dphone", mobile);
                    cmd.Parameters.AddWithValue("@dpass", oldpass);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        dr.Close();
                        cmd.CommandText = "update drivertbl set password=@newpass where mobilenumber=@dphone";
                        cmd.Parameters.Add("@newpass", newpass);
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception e1)
                {
                    return -1;
                }
            }
            catch (Exception e2)
            {
                return -2;
            }
            
        }


        public int customerchangepass(String mobile, String oldpass, String newpass)
        {

            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from customertbl where phone_no=@dphone and password=@dpass";
                    cmd.Parameters.AddWithValue("@dphone", mobile);
                    cmd.Parameters.AddWithValue("@dpass", oldpass);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        dr.Close();
                        cmd.CommandText = "update customertbl set password=@newpass where phone_no=@dphone";
                        cmd.Parameters.Add("@newpass", newpass);
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception e1)
                {
                    return -1;
                }
            }
            catch (Exception e2)
            {
                return -2;
            }

        }





        public String getcustomerpass(String mobile)
        {
            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from customertbl where phone_no=@dphone";
                    cmd.Parameters.AddWithValue("@dphone", mobile);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        String pass = dr["password"].ToString();
                        return pass;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e1)
                {
                    return "noconnection";
                }
            }
            catch (Exception e2)
            {
                return "internalerror";
            }
         }



        public String getdriverpass(String mobile)
        {
            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from drivertbl where mobilenumber=@dphone";
                    cmd.Parameters.AddWithValue("@dphone", mobile);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        String pass = dr["password"].ToString();
                        return pass;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e1)
                {
                    return "noconnection";
                }
            }
            catch (Exception e2)
            {
                return "internalerror";
            }
        }



        public int driverlogincheck(String dmobile, String dpass)
        {
            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from drivertbl where mobilenumber=@dphone and password=@dpass";
                    cmd.Parameters.AddWithValue("@dphone", dmobile);
                    cmd.Parameters.AddWithValue("@dpass", dpass);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ed1)
                {
                    return -1;
                }
            }
            catch(Exception ed2)
            {
                return -2;
            }
        }



        /*    public string modifyrequest(int id, String booking, String delivery, String gst_no, String pay_type, String vehicle_no, String lr_total, String ack_status, String pod_uploded_status)
            {
                SqlConnection con = makeconnection();
                con.Open();


                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update vrequest set booking=@booking, delivery=@delivery, gst_no=@gst_no, pay_type=@pay_type, vehicle_no=@vehicle_no, lr_total=@lr_total, ack_status=@ack_status, pod_uploded_status=@pod_uploded_status where id=@id";
                    cmd.Parameters.Add("@booking", booking);
                    cmd.Parameters.Add("@delivery", delivery);

                    cmd.Parameters.Add("@gst_no", gst_no);
                    cmd.Parameters.Add("@pay_type", pay_type);
                    cmd.Parameters.Add("@vehicle_no", vehicle_no);
                    cmd.Parameters.Add("@lr_total", lr_total);
                    cmd.Parameters.Add("@ack_status", ack_status);
                    cmd.Parameters.Add("@pod_uploded_status", pod_uploded_status);
                    cmd.Parameters.Add("@id", id);
                    cmd.ExecuteNonQuery();
                    return "1";
                }
                catch (Exception e1)
                {
                    return e1.Message;
                }


            }*/



        public static byte[] ReadAllStream(Stream s)
        {
            MemoryStream ms = new MemoryStream();
            byte[] b = new byte[10240];
            int n;
            while ((n = s.Read(b, 0, b.Length)) > 0)
            {
                ms.Write(b, 0, n);
            }
            b = ms.ToArray();
            ms.Dispose();
            return b;

        }




        public string vehiclerequest(String type, String source, String destination, String billing, String quantity, int weight, String date, String time)
        {
            try
            {
                SqlConnection con = makeconnection();
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into vrequest(vehicle_type,consignor,consignee,billing_party,quantity,weight,date,time) values(@vt,@cnr,@cne,@bp,@qut,@wig,@date,@time)";
                    cmd.Parameters.AddWithValue("@vt", type);
                    cmd.Parameters.AddWithValue("@cnr", source);
                    cmd.Parameters.AddWithValue("@cne", destination);
                    cmd.Parameters.AddWithValue("@bp", billing);
                    cmd.Parameters.AddWithValue("@qut", quantity);
                    cmd.Parameters.AddWithValue("@wig", weight);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.ExecuteNonQuery();
                    return "1";
                }
                catch (Exception e2)
                {
                    return e2.Message;
                }
            }
            catch (Exception e1)
            {
                return "-2";
            }

            
        }



    }
}