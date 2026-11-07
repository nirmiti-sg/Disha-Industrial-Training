package com.example.project;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class driverchangepass extends AppCompatActivity {


    String drivmobile;

    EditText etdop, etdnp;

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_driverchangepass);

        Intent i = getIntent();
        drivmobile = i.getStringExtra("drivmobile");
        etdop = findViewById(R.id.etdoldPassword);
        etdnp = findViewById(R.id.etdnewPassword);

    }

    public void changedriverpassword(View v) {
         Toast.makeText(driverchangepass.this, "hello", Toast.LENGTH_LONG).show();
        try {


            if (etdop.getText().toString().equalsIgnoreCase("")) {

                etdop.setError("Enter Old Password");
            } else if (etdnp.getText().toString().equalsIgnoreCase("")) {
                etdnp.setError("Enter New Password");
            } else {
                new AsyncTask<Void, Void, String>() {
                    @Override
                    protected String doInBackground(Void... voids) {
                        try {
                            String url = "https://dishatrans.tissa.in/drivercp.ashx?mn=" + drivmobile + "&op=" + etdop.getText().toString() + "&np=" + etdnp.getText().toString();
                            String result = webservices.get(url);
                            return result;
                        } catch (Exception e1) {
                            return e1.getMessage().toString();
                        }
                    }

                    @Override
                    protected void onPostExecute(String s) {
                        int res = Integer.parseInt(s);
                        super.onPostExecute(s);
                        if (res == 1) {
                            Toast.makeText(driverchangepass.this, "Password Changed", Toast.LENGTH_LONG).show();
                            etdnp.setText("");
                            etdop.setText("");
                        } else if (res == 0) {
                            Toast.makeText(driverchangepass.this, "Invalid old Password", Toast.LENGTH_LONG).show();
                            etdop.setText("");
                            etdop.requestFocus();
                        } else {
                            Toast.makeText(driverchangepass.this, "Try Again!", Toast.LENGTH_LONG).show();
                        }
                    }
                }.execute();
            }

        } catch (Exception e1) {
            Toast.makeText(driverchangepass.this, e1.getMessage().toString(), Toast.LENGTH_LONG).show();
        }
    }

}

