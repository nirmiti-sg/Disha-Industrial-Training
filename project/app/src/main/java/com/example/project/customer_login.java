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

public class customer_login extends AppCompatActivity {

    EditText etcluname,etclpass;
    Button btclogin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_customer_login);

        etcluname=findViewById(R.id.etcustloguser);
        etclpass=findViewById(R.id.etcustlogpass);
        btclogin=findViewById(R.id.btnclogin);





btclogin.setOnClickListener(new View.OnClickListener() {
    @Override
    public void onClick(View v)
    {
        String n,p;

        n=etcluname.getText().toString();
        p=etclpass.getText().toString();
                    if (etcluname.getText().toString().equals(""))
                    {
                        etcluname.setError("Enter User name");
                    }
                    else if (etclpass.getText().toString().equals(""))
                    {
                        etclpass.setError("Enter Password");
                    }
                    else
                    {


                        new AsyncTask<Void, Void, String>() {
                            @Override
                            protected String doInBackground(Void... voids)
                            {
                                try {
                                    String url="https://dishatrans.tissa.in/customer_login.ashx?cphone="+n+"&cpass="+p;
                                    String res = webservices.get(url);
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
                                    Intent i=new Intent(customer_login.this,customer_homepage.class);
                                    i.putExtra("custmobile",n);
                                    localdb l=new localdb(customer_login.this);
                                    l.addcustomerlogin(n);
                                    startActivity(i);
                                    finish();
                                }
                                else
                                {
                                    Toast.makeText(customer_login.this,s,Toast.LENGTH_SHORT).show();
                                   // etcluname.setText("");
                                   // etclpass.setText("");
                                   // etcluname.requestFocus();
                                }
                            }
                        }.execute();



                    }
    }
});

    }
    public void openCustomerhomepage()
    {
//        Toast.makeText(this,"button licked",Toast.LENGTH_SHORT).show();
    }


    public void opencsignuppage(View v)
    {
        Intent i=new Intent(customer_login.this, cust_signup.class);
         startActivity(i);
    }

  public void opennewpass(View v)
   {
      Intent i=new Intent(customer_login.this, customerforgetpass.class);
       startActivity(i);
   }
}