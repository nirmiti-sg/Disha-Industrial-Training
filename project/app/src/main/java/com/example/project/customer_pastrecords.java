package com.example.project;

import android.content.Intent;
import android.os.Bundle;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class customer_pastrecords extends AppCompatActivity {

    WebView wvc;
    String custmobile;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_customer_pastrecords);

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        Intent i = getIntent();
        custmobile = i.getStringExtra("custmobile");

        wvc = findViewById(R.id.wvcustomer);
        WebSettings webSettings = wvc.getSettings();
        webSettings.setJavaScriptEnabled(true);
        wvc.setWebChromeClient(new WebChromeClient());
        wvc.setWebViewClient(new WebViewClient());

        // ✅ Correct URL with query string
        wvc.loadUrl("https://dishatrans.tissa.in/customerhistory.aspx?custmobile=" + custmobile);
    }
}
