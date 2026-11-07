package com.example.project;

import android.content.Intent;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class customer_requesvehicle extends AppCompatActivity {

    Spinner vtype,destination;
    EditText bparty,qty,wt,date1,time1,pono, partno,source;
    Button btnsend;
    String custmobile;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_customer_requesvehicle);

        vtype = findViewById(R.id.dropdown1);
        source = findViewById(R.id.etsourceaddress);
        destination = findViewById(R.id.dropdown3);
        bparty = findViewById(R.id.billingp);
        qty = findViewById(R.id.cquantity);
        wt = findViewById(R.id.cweight);
        date1 = findViewById(R.id.cdate);
        time1 = findViewById(R.id.ctime);
        pono=findViewById(R.id.cpono);
        partno=findViewById(R.id.cpartno);
        btnsend=findViewById(R.id.sendreq);
        Intent i=getIntent();
        custmobile=i.getStringExtra("custmobile");


        new AsyncTask<Void, Void, String>() {
            @Override
            protected String doInBackground(Void... voids)
            {
                String url="https://dishatrans.tissa.in/getpartylocation.ashx?mobile="+custmobile;
                try
                {
                    String result=webservices.get(url);
                    return result;
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
                source.setText(s);
                source.setFocusable(false);
                source.setClickable(false);
            }
        }.execute();


        new AsyncTask<Void, Void, String>()
        {
            @Override
            protected String doInBackground(Void... voids)
            {
                String url="https://dishatrans.tissa.in/getdestination.ashx";
                try {
                    String result = webservices.get(url);
                    return result;
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

                // Convert JSON string to list
                List<String> companyList = jsonToList(s);

                // Create adapter
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(
                        customer_requesvehicle.this,   // use Activity context
                        android.R.layout.simple_spinner_item,
                        companyList
                ) {
                    @Override
                    public View getView(int position, View convertView, ViewGroup parent) {
                        View view = super.getView(position, convertView, parent);
                        ((TextView) view).setTextColor(Color.BLACK); // make selected item visible
                        return view;
                    }
                };
                adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                destination.setAdapter(adapter);
            }
        }.execute();



// load self location
        new AsyncTask<Void, Void, String>() {
            @Override
            protected String doInBackground(Void... voids)
            {
                String url="https://dishatrans.tissa.in/getpartylocation.ashx?mobile="+custmobile;
                try
                {
                    String result=webservices.get(url);
                    return result;
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
                source.setText(s);
                source.setFocusable(false);
                source.setClickable(false);
            }
        }.execute();







        // load vehicle type



        new AsyncTask<Void, Void, String>()
        {
            @Override
            protected String doInBackground(Void... voids)
            {
                String url="https://dishatrans.tissa.in/getvehicletype.ashx";
                try {
                    String result = webservices.get(url);
                    return result;
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

                // Convert JSON string to list
                List<String> vehicletype = jsonToList(s);

                // Create adapter
                ArrayAdapter<String> adapter = new ArrayAdapter<String>(
                        customer_requesvehicle.this,   // use Activity context
                        android.R.layout.simple_spinner_item,
                        vehicletype
                ) {
                    @Override
                    public View getView(int position, View convertView, ViewGroup parent) {
                        View view = super.getView(position, convertView, parent);
                        ((TextView) view).setTextColor(Color.BLACK); // make selected item visible
                        return view;
                    }
                };
                adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                vtype.setAdapter(adapter);
            }
        }.execute();




        btnsend.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v) {
                String vehicletype, consigner, consignee, billingparty, quantity, weight, date, time,ponum,partnum;

                vehicletype = vtype.getSelectedItem().toString();
                consigner = source.getText().toString();
                consignee = destination.getSelectedItem().toString();
                billingparty = bparty.getText().toString();
                quantity = qty.getText().toString();
                weight = wt.getText().toString();
                date = date1.getText().toString();
                time = time1.getText().toString();
                ponum= pono.getText().toString();
                partnum=partno.getText().toString();


                if (bparty.getText().toString().isEmpty()) {
                    bparty.setError("Enter billing party");
                } else if (qty.getText().toString().isEmpty()) {
                    qty.setError("Enter quantity");
                } else if (wt.getText().toString().isEmpty()) {
                    wt.setError("Enter weight.");
                } else if (date1.getText().toString().isEmpty()) {
                    date1.setError("Enter date");
                } else if (time1.getText().toString().isEmpty()) {
                    time1.setError("Enter time");
                } else {
                    HashMap<String,String> map=new HashMap<>();
                    map.put("vtype",vehicletype);
                    map.put("source",consigner);
                    map.put("destination",consignee);
                    map.put("billingp",billingparty);
                    map.put("quantity",quantity);
                    map.put("weight",weight);
                    map.put("date",date);
                    map.put("time",time);
                    map.put("pono",ponum);
                    map.put("partno",partnum);
                    map.put("custmobile",custmobile);


                    String Json=new JSONObject(map).toString();
                    new AsyncTask<Void, Void, String>() {
                        @Override
                        protected String doInBackground(Void... voids)
                        {
                            String url="https://dishatrans.tissa.in/vehicle_request.ashx";
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
                                Toast.makeText(customer_requesvehicle.this,"request sent",Toast.LENGTH_LONG).show();
                                Intent i=new Intent(customer_requesvehicle.this, customer_homepage.class);
                                startActivity(i);
                                finish();
                            }
                            else
                            {
                                Toast.makeText(customer_requesvehicle.this,s,Toast.LENGTH_LONG).show();
                            }

                        }
                    }.execute();
                }
            }
        });


    }


    public List<String> jsonToList(String jsonString) {
        List<String> itemList = new ArrayList<>();
        try {
            JSONArray jsonArray = new JSONArray(jsonString);
            for (int i = 0; i < jsonArray.length(); i++) {
                itemList.add(jsonArray.getString(i));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return itemList;
    }


            /*public void opencusthomepage(View v) {
                Toast.makeText(customer_requesvehicle.this,"request sent",Toast.LENGTH_SHORT).show();
                Intent i = new Intent(customer_requesvehicle.this, customer_homepage.class);
                startActivity(i);

            }*/

            public void opencustomerhomepage(View v)
            {
                Intent i=new Intent(customer_requesvehicle.this, customer_homepage.class);
                startActivity(i);
            }







    }
