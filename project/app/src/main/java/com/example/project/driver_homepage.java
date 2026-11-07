package com.example.project;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class driver_homepage extends AppCompatActivity {

    String drivmobile;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_driver_homepage);


        Intent i=getIntent();
        drivmobile=i.getStringExtra("drivmobile");
        }


    public void driverlogout(View v)
    {
        localdb l=new localdb(driver_homepage.this);
        l.deldriver();
        Intent i=new Intent(driver_homepage.this,main.class);
        startActivity(i);
        finish();
    }

    public void opendriverpastrecords(View v) {
        Intent i = new Intent(driver_homepage.this, driver_pastrecords.class);
        i.putExtra("drivmobile",drivmobile);
        startActivity(i);
    }

    public void opencontact(View v){
        Intent i=new Intent(driver_homepage.this,contact_person.class);
        startActivity(i);
    }

    public void openhelp(View v){
        Intent i= new Intent(driver_homepage.this,chat.class);
        startActivity(i);
    }

    public void openchangepass(View v){
        Intent i= new Intent(driver_homepage.this,driverchangepass.class);
        i.putExtra("drivmobile",drivmobile);
        startActivity(i);
    }
}


