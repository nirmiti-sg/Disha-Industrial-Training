package com.example.project;

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

public class changepass extends AppCompatActivity {


    String custmobile;

    EditText etop,etnp;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_changepass);

        Intent i=getIntent();
        custmobile=i.getStringExtra("custmobile");

       etop=findViewById(R.id.etcOldPassword);
       etnp=findViewById(R.id.etcNewPassword);


    }


    public void changecustomerpassword(View v) {
       // Toast.makeText(changepass.this, "hi", Toast.LENGTH_LONG).show();
        try {


            if (etop.getText().toString().equalsIgnoreCase("")) {

                etop.setError("Enter Old Password");
            } else if (etnp.getText().toString().equalsIgnoreCase("")) {
                etnp.setError("Enter New Password");
            } else {
                new AsyncTask<Void, Void, String>() {
                    @Override
                    protected String doInBackground(Void... voids) {
                        try {
                            String url = "https://dishatrans.tissa.in/customercp.ashx?mn=" + custmobile + "&op=" + etop.getText().toString() + "&np=" + etnp.getText().toString();
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
                            Toast.makeText(changepass.this, "Password Changed", Toast.LENGTH_LONG).show();
                            etnp.setText("");
                            etop.setText("");
                        } else if (res == 0) {
                            Toast.makeText(changepass.this, "Invalid old Password", Toast.LENGTH_LONG).show();
                            etop.setText("");
                            etop.requestFocus();
                        } else {
                            Toast.makeText(changepass.this, "Try Again!", Toast.LENGTH_LONG).show();
                        }
                    }
                }.execute();
            }

        }catch (Exception e1)
        {
            Toast.makeText(changepass.this,e1.getMessage().toString(),Toast.LENGTH_LONG).show();
        }

    }
}