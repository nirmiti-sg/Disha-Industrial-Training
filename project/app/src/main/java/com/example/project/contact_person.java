package com.example.project;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import org.w3c.dom.Text;

public class contact_person extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_contact_person);

        ImageButton callButton1 = findViewById(R.id.imageCall1);
        TextView phone1 = findViewById(R.id.phoneno1);
        callButton1.setOnClickListener(v -> makeCall(phone1.getText().toString()));

        ImageButton callButton2 = findViewById(R.id.imageCall2);
        TextView phone2 = findViewById(R.id.phoneno2);
        callButton2.setOnClickListener(v -> makeCall(phone2.getText().toString()));

        ImageButton callButton3 = findViewById(R.id.imageCall3);
        TextView phone3 = findViewById(R.id.phoneno3);
        callButton3.setOnClickListener(v -> makeCall(phone3.getText().toString()));

        ImageButton callButton4 = findViewById(R.id.imageCall4);
        TextView phone4 = findViewById(R.id.phoneno4);
        callButton4.setOnClickListener(v -> makeCall(phone4.getText().toString()));

        ImageButton callButton5 = findViewById(R.id.imageCall5);
        TextView phone5 = findViewById(R.id.phoneno5);
        callButton5.setOnClickListener(v -> makeCall(phone5.getText().toString()));

        ImageButton callButton6 = findViewById(R.id.imageCall6);
        TextView phone6 = findViewById(R.id.phoneno6);
        callButton6.setOnClickListener(v -> makeCall(phone6.getText().toString()));

        ImageButton callButton7 = findViewById(R.id.imageCall7);
        TextView phone7 = findViewById(R.id.phoneno7);
        callButton7.setOnClickListener(v -> makeCall(phone7.getText().toString()));

    }

    private void makeCall(String PhoneNumber){
        Intent intent = new Intent(Intent.ACTION_DIAL);
        intent.setData(Uri.parse("tel:" + PhoneNumber));
        startActivity(intent);
    }

       /* callButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String phoneNumber = "9226984289";
                Intent intent = new Intent(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:" + phoneNumber));
                startActivity(intent);
            }
*/


}