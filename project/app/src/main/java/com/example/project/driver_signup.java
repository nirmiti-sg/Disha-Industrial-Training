package com.example.project;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import android.view.WindowManager;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import org.json.JSONObject;

import java.util.HashMap;

import javax.xml.transform.Result;

public class driver_signup extends AppCompatActivity {

    
    EditText etdsname, etdsphoneno, etdsaddress, etdsmailid, etdsvehicletype, etdsvehicleno, etdspass;
    Button btdrivsignup;
    
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_driver_signup);


        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_ADJUST_RESIZE);

        etdsname=findViewById(R.id.driverinputname);
        etdsphoneno=findViewById(R.id.driverinputphoneno);
        etdsmailid=findViewById(R.id.driverinputmailid);
        etdsaddress=findViewById(R.id.driverinputaddress);
        etdsvehicletype=findViewById(R.id.driverinputvehicletype);
        etdsvehicleno=findViewById(R.id.driverinputvehicleno);
        etdspass=findViewById(R.id.driverinputpassword);
        btdrivsignup=findViewById(R.id.btndrivsignup);

        btdrivsignup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)  {
                String name,phoneno,address,email,vehicletype,vehicleno,password;

                name=etdsname.getText().toString();
                phoneno=etdsphoneno.getText().toString();
                address=etdsaddress.getText().toString();
                email=etdsmailid.getText().toString();
                vehicleno=etdsvehicleno.getText().toString();
                vehicletype=etdsvehicletype.getText().toString();
                password=etdspass.getText().toString();

                if (etdsname.getText().toString().isEmpty()) {
                    etdsname.setError("enter name");
                } else if (etdsphoneno.getText().toString().isEmpty()) {
                    etdsphoneno.setError("enter phone no");
                } else if (etdsaddress.getText().toString().isEmpty()) {
                    etdsaddress.setError("Enter address");
                } else if (etdsmailid.getText().toString().isEmpty()) {
                    etdsmailid.setError("Enter email address");
                } else if (etdsvehicletype.getText().toString().isEmpty()) {
                    etdsvehicletype.setError("Enter vehicle type");
                } else if(etdsvehicleno.getText().toString().isEmpty()){
                    etdsvehicleno.setError("Enter vehicle no.");
                }else if(etdspass.getText().toString().isEmpty()){
                    etdspass.setError("Enter password");
                }
                else{

                    HashMap<String,String> map=new HashMap<>();
                    map.put("dname",name);
                    map.put("mobile",phoneno);
                    map.put("email",email);
                    map.put("address",address);
                    map.put("vnum",vehicleno);
                    map.put("vtype",vehicletype);
                    map.put("pass",password);

                    String Json=new JSONObject(map).toString();
                    new AsyncTask<Void, Void, String>() {
                        @Override
                        protected String doInBackground(Void... voids)
                        {
                            String url="https://dishatrans.tissa.in/driver_register.ashx";
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
                                Intent i=new Intent(driver_signup.this, driver_login.class);
                                startActivity(i);
                                finish();
                            }
                            else
                            {
                                Toast.makeText(driver_signup.this,s,Toast.LENGTH_LONG).show();
                            }

                        }
                    }.execute();


                }
            }
        });
    }
  /*  public void opendriverhomepage(View v) {
        Intent i = new Intent(driver_signup.this, driver_homepage.class);
        startActivity(i);

    }*/
}

















