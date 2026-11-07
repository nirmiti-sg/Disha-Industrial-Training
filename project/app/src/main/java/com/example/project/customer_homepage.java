package com.example.project;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class customer_homepage extends AppCompatActivity {


    String custmobile;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_customer_homepage);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });


        Intent i=getIntent();
        custmobile=i.getStringExtra("custmobile");

    }


    public void customerlogout(View v)
    {
        localdb l=new localdb(customer_homepage.this);
        l.delcustomer();
        Intent i=new Intent(customer_homepage.this,main.class);
        startActivity(i);
        finish();
    }

    public void openvehiclerequest(View v) {
        Intent i = new Intent(customer_homepage.this, customer_requesvehicle.class);
        i.putExtra("custmobile",custmobile);
        startActivity(i);
    }

    public void opencustomerpastrecords(View v) {
        Intent i = new Intent(customer_homepage.this, customer_pastrecords.class);
        i.putExtra("custmobile",custmobile);
        startActivity(i);
    }

    public void opencontact(View v){
        Intent i=new Intent(customer_homepage.this,contact_person.class);
        startActivity(i);
    }

    public void openhelp(View v){
        Intent i= new Intent(customer_homepage.this,chat.class);
        startActivity(i);
    }
    public void openchangepass(View v){
        Intent i= new Intent(customer_homepage.this,changepass.class);
        i.putExtra("custmobile",custmobile);
        startActivity(i);
    }
}