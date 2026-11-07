package com.example.project;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import org.json.JSONObject;

import java.util.HashMap;

public class cust_signup extends AppCompatActivity {


    EditText etcspname,etcspaddress,etcscname, etcsphoneno, etcspanno, etcsgstno, etcspass;
    Button btcustsignup;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_cust_signup);

        etcspname=findViewById(R.id.custinputpname);
        etcspaddress=findViewById(R.id.custinputpaddress);
        etcscname=findViewById(R.id.custinputcname);
        etcsphoneno=findViewById(R.id.custinputphoneno);
        etcspanno=findViewById(R.id.custinputpanno);
        etcsgstno=findViewById(R.id.custinputgstno);
        etcspass=findViewById(R.id.custinputpass);
       btcustsignup=findViewById(R.id.btncustsignup);


       btcustsignup.setOnClickListener(new View.OnClickListener() {
           @Override
           public void onClick(View v) {
               String pname,paddress,cname,phone,panno,gstno,password;
               pname=etcspname.getText().toString();
               paddress=etcspaddress.getText().toString();
               cname=etcscname.getText().toString();
               phone=etcsphoneno.getText().toString();
               panno=etcspanno.getText().toString();
               gstno=etcsgstno.getText().toString();
               password=etcspass.getText().toString();

               if(etcspname.getText().toString().equals(" ")) {
                   etcspname.setError("Enter party name");
               }
               else if (etcspaddress.getText().toString().equals(" ")) {
                   etcspaddress.setError("Enter party address");
               }
               else if (etcscname.getText().toString().equals(" ")) {
                   etcscname.setError("Enter contact person name");
               }
               else if (etcsphoneno.getText().toString().equals(" ")) {
                   etcsphoneno.setError("Enter phone no.");
               }
               else if (etcspanno.getText().toString().equals(" ")) {
                   etcspanno.setError("Enter pan no.");
               }
               else if(etcsgstno.getText().toString().isEmpty()){
                   etcsgstno.setError("Enter GST no.");
               }
               else if(etcspass.getText().toString().isEmpty()){
                   etcspass.setError("Enter password");
               }
               else{

                   HashMap<String,String> map=new HashMap<>();
                   map.put("pname",pname);
                   map.put("address",paddress);
                   map.put("cname",cname);
                   map.put("phoneno",phone);
                   map.put("panno",panno);
                   map.put("gstno",gstno);
                   map.put("pass",password);

                   String Json=new JSONObject(map).toString();
                   new AsyncTask<Void, Void, String>() {
                       @Override
                       protected String doInBackground(Void... voids)
                       {
                           String url="https://dishatrans.tissa.in/customer_register.ashx";
                           try {
                               String res=webservices.post(url,Json);
                               return res;
                           }
                           catch (Exception e1)
                           {
                               return e1.getMessage().toString();
                           }
                       }

                       @Override
                       protected void onPostExecute(String s)
                       {
                           super.onPostExecute(s);

                           if (s.equalsIgnoreCase("success"))
                           {
                               Intent i=new Intent(cust_signup.this, customer_login.class);
                               startActivity(i);
                               finish();
                           }
                           else
                           {
                               Toast.makeText(cust_signup.this,s,Toast.LENGTH_LONG).show();
                           }
                       }
                   }.execute();

                   //opencustomerhomepage(v);
               }
           }
       });
    }

   /* public void opencustomerhomepage(View v)
    {
        Intent i= new Intent(cust_signup.this, customer_homepage.class);
        startActivity(i);
    }
*/
}