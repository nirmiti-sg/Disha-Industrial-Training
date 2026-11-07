package com.example.project;

import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ScrollView;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import java.util.HashMap;

public class chat extends AppCompatActivity {

    private LinearLayout chatLayout;
    private EditText etMessage;
    private Button btnSend;
    private ScrollView scrollView;
    private Spinner spinnerFAQ;

    private HashMap<String, String> qaMap;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chat);

        chatLayout = findViewById(R.id.chatLayout);
     //   etMessage = findViewById(R.id.etMessage);
     //   btnSend = findViewById(R.id.btnSend);
        scrollView = findViewById(R.id.scrollView);
        spinnerFAQ = findViewById(R.id.spinnerFAQ);

        qaMap = new HashMap<>();
        qaMap.put("What should I do if my internet is slow and booking fails?",
                "👉 Retry when you have better connectivity. Booking requires stable internet.");
        qaMap.put("Why is my data not showing in past records?",
                "👉 Make sure you are logged in with the correct account. If issue continues, contact support.");
        qaMap.put("How do I report a bug or error in the app?",
                "👉 Go to Help → Chat with Admin and describe the issue.");
        qaMap.put("How can I check my past booking records?",
                "👉 Tap Past Records on your dashboard to see all your completed bookings.");
        qaMap.put("How do I contact support for other issues?",
                "👉 Use the Help → Chat with Admin option to reach our support team.");
        qaMap.put("Who should I contact if billing details are wrong?",
                "👉 Please contact Admin via contact person for correction.");
        qaMap.put("How long does it take to confirm my booking?",
                "👉 Usually within a few minutes, once a driver is assigned.");
        qaMap.put("Can I cancel my request after booking?",
                "👉 Yes, you can cancel before the driver starts the trip.");
        qaMap.put("Will I get a receipt after completing the trip?",
                "👉 Yes, a digital invoice will be generated automatically in the app.");
        qaMap.put("What if I face an issue with the customer?",
                "👉 Use Help → Chat with Admin and report immediately.");
        qaMap.put("How do I check my past trips and earnings?",
                "👉 Tap Past Records to see all completed trips and billing details.");


        String[] questions = qaMap.keySet().toArray(new String[0]);
        ArrayAdapter<String> adapter = new ArrayAdapter<>(
                this,
                android.R.layout.simple_spinner_item,
                questions
        );
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerFAQ.setAdapter(adapter);


        spinnerFAQ.setOnItemSelectedListener(new android.widget.AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(android.widget.AdapterView<?> parent, View view, int position, long id) {
                String selectedQuestion = (String) parent.getItemAtPosition(position);
                if (selectedQuestion != null && qaMap.containsKey(selectedQuestion)) {
                    addMessage(selectedQuestion, true); // user question
                    addMessage(qaMap.get(selectedQuestion), false); // bot answer
                }
            }

            @Override
            public void onNothingSelected(android.widget.AdapterView<?> parent) {
            }
        });


     /*   btnSend.setOnClickListener(v -> {
            String message = etMessage.getText().toString().trim();
            if (!message.isEmpty()) {
                addMessage(message, true); // user message
                respondMessage(message.toLowerCase());
                etMessage.setText("");
            }
        });*/
    }

    private void addMessage(String message, boolean isUser) {
        TextView tv = new TextView(this);
        tv.setText(message);
        tv.setTextSize(16);
        tv.setPadding(15, 10, 15, 10);

        LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.WRAP_CONTENT,
                LinearLayout.LayoutParams.WRAP_CONTENT
        );

        if (isUser) {
            params.gravity = Gravity.END;
            tv.setBackgroundColor(0xFF002680); // dark red
            tv.setTextColor(0xFFFFFFFF);
        } else {
            params.gravity = Gravity.START;
            tv.setBackgroundColor(0xFFE0E0E0); // light gray
            tv.setTextColor(0xFF000000);
        }

        params.setMargins(10, 5, 10, 5);
        tv.setLayoutParams(params);

        chatLayout.addView(tv);
        scrollView.post(() -> scrollView.fullScroll(View.FOCUS_DOWN));
    }


    private void respondMessage(String userMessage) {
        String reply = "Sorry, I don’t understand 🤔";
        if (userMessage.contains("hi") || userMessage.contains("hello") || userMessage.contains("hey")) {
            reply = "Hi! How can I help you?";
        }
        else if (userMessage.contains("bye") || userMessage.contains("goodbye")) {
            reply = "Our team is here whenever you need help 😊";
        }
        else {
            for (String key : qaMap.keySet()) {
                if (userMessage.contains(key.toLowerCase())) {
                    reply = qaMap.get(key);
                    break;
                }
            }
        }

        addMessage(reply, false); // show bot reply once
    }

}

