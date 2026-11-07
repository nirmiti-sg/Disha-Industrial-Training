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

public class driver_pastrecords extends AppCompatActivity {

    WebView wvd;
    String drivermobile;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_driver_pastrecords);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        Intent i=getIntent();
        drivermobile=i.getStringExtra("drivmobile");
        wvd=findViewById(R.id.wvdriver);
        WebSettings webSettings = wvd.getSettings();
        webSettings.setJavaScriptEnabled(true);
        wvd.setWebChromeClient(new WebChromeClient());
        wvd.setWebViewClient(new WebViewClient());
        wvd.loadUrl("https://dishatrans.tissa.in/driverhistory.aspx?mobile="+drivermobile);
    }
}