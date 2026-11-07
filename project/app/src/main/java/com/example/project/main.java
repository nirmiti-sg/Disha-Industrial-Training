package com.example.project;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class main extends AppCompatActivity {


    ImageButton btnmcatagory, btnccatagory, btndcatagory;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });



        localdb l=new localdb(this);
        String cmob=l.checkcustomer();
        if (cmob!=null)
        {
            Intent i=new Intent(this,customer_homepage.class);
            i.putExtra("custmobile",cmob);
            startActivity(i);
            finish();
        }
        else
        {

        }


        localdb l1=new localdb(this);
        String dmob=l1.checkdriver();
        if (dmob!=null)
        {
            Intent i=new Intent(this,driver_homepage.class);
            i.putExtra("drivmobile",cmob);
            startActivity(i);
            finish();
        }
        else
        {

        }






    }



    public void openManager(View v)
    {

    }

    public void openCustomer(View v)
    {
    Intent i=new Intent(main.this,customer_login.class);
    startActivity(i);
    finish();
    }

    public void openDriver(View v)
    {
        Intent i=new Intent(main.this, driver_login.class);
        startActivity(i);
        finish();
    }

}