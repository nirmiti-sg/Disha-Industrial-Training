package com.example.project;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class forgotpass extends AppCompatActivity {



EditText etmn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_forgotpass);


        if (ActivityCompat.checkSelfPermission(this, android.Manifest.permission.SEND_SMS)
                != PackageManager.PERMISSION_GRANTED)
        {
            ActivityCompat.requestPermissions(this,
                    new String[]{android.Manifest.permission.SEND_SMS},
                    1);
        }

        etmn=findViewById(R.id.etfgdrivermobile);


    }




    public  void drivergetpass(View v)
    {
        String mobile;

        if (etmn.getText().toString().equalsIgnoreCase(""))
        {
            etmn.setError("Enter Mobile Number");
        }
        else
        {
            mobile=etmn.getText().toString().trim();

            new AsyncTask<Void, Void, String>() {
                @Override
                protected String doInBackground(Void... voids)
                {

                    try {
                        String url="https://dishatrans.tissa.in/drivergetpass.ashx?mobile="+mobile;
                        String result=webservices.get(url);
                        return  result;
                    }
                    catch (Exception e1)
                    {
                        Toast.makeText(forgotpass.this,e1.getMessage().toString(),Toast.LENGTH_LONG).show();

                        return null;
                    }

                }

                @Override
                protected void onPostExecute(String s)
                {
                    super.onPostExecute(s);
                    if (ActivityCompat.checkSelfPermission(forgotpass.this, Manifest.permission.SEND_SMS)
                            != PackageManager.PERMISSION_GRANTED)
                    {
                        ActivityCompat.requestPermissions(forgotpass.this,
                                new String[]{Manifest.permission.SEND_SMS},
                                1);
                    }


                    SmsManager sm= SmsManager.getDefault();
                    sm.sendTextMessage(mobile,null,"your Password is "+s,null,null);
                    Toast.makeText(forgotpass.this,"Password Sent on your Registored mobile",Toast.LENGTH_LONG).show();
                    Intent i= new Intent(forgotpass.this, driver_login.class);
                    startActivity(i);
                    finish();
                }
            }.execute();



        }


    }
}