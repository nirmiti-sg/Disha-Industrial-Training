package com.example.project;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.ViewGroup;
import android.widget.ImageView;
import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;

public class SplashActivity extends AppCompatActivity {

    ImageView applogo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_splashactivity);

        applogo = findViewById(R.id.mainimage);

       new Handler().postDelayed(() -> {
            animateLogo();
        }, 2000);


    }

        private void animateLogo()
        {
            applogo.animate()
                    .x(1)
                    .y(0)
                    .scaleX(0.6f)
                    .scaleY(0.6f)
                    .setDuration(800)
                    .withEndAction(()->{

                        ViewGroup.LayoutParams params= applogo.getLayoutParams();
                        params.width=ViewGroup.LayoutParams.WRAP_CONTENT;
                        params.height=ViewGroup.LayoutParams.WRAP_CONTENT;

                        applogo.setLayoutParams(params);
                        applogo.requestLayout();

                        Intent i=new Intent(SplashActivity.this, main.class);
                        startActivity(i);
                        finish();
                    });

        }
    }
