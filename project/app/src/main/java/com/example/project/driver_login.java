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

public class driver_login extends AppCompatActivity {


    EditText etdluname,etdlpass;
    Button btdlogin;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_driver_login);

        etdluname=findViewById(R.id.etdrivloguser);
        etdlpass=findViewById(R.id.etdrivlogpass);
        btdlogin=findViewById(R.id.btndlogin);

        btdlogin.setOnClickListener(new View.OnClickListener() {


            @Override
            public void onClick(View v) {

                String n,p;

                n=etdluname.getText().toString();
                p=etdlpass.getText().toString();
                if (etdluname.getText().toString().equals(""))
                {
                    etdluname.setError("Enter User name");
                }
                else if (etdlpass.getText().toString().equals(""))
                {
                    etdlpass.setError("Enter Password");
                }
                else
                {
                    new AsyncTask<Void,Void,String>() {
                        @Override
                        protected String doInBackground(Void... voids)
                        {
                            String res= null;
                            try
                            {
                                String url="https://dishatrans.tissa.in/driver_login.ashx?dphone="+n+"&dpass="+p;
                                res = webservices.get(url);
                                return  res;
                            } catch (Exception e)
                            {

                                return e.getMessage().toString();
                            }

                        }

                        @Override
                        protected void onPostExecute(String s)
                        {
                            super.onPostExecute(s);

                            if (s.equalsIgnoreCase("success"))
                            {

                                Intent i =new Intent(driver_login.this,driver_homepage.class);
                                i.putExtra("drivmobile",n);
                                localdb l=new localdb(driver_login.this);
                                l.adddriverlogin(n);
                                startActivity(i);
                                finish();
                            }
                            else
                            {
                                Toast.makeText(driver_login.this,"Invalid credentials",Toast.LENGTH_LONG).show();
                                etdluname.setText("");
                                etdlpass.setText("");
                                etdluname.requestFocus();
                            }
                        }
                    }.execute();





                }
            }
        });
    }

  /*  public void opendriverhomepage(View v)
    {

    }*/
    public void opennewpass(View v)
    {
        Intent i=new Intent(driver_login.this, forgotpass.class);
        startActivity(i);
    }
    public void opendsignuppage(View v)
    {
        Intent i= new Intent(driver_login.this, driver_signup.class);
                startActivity(i);
    }
}