package com.example.project;

import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;


public class webservices {
    public static String get(String url) throws Exception {
        URL u = new URL(url);
        HttpURLConnection con = (HttpURLConnection) u.openConnection();
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        byte[] b = new byte[10240];
        int n;
        InputStream is = con.getInputStream();
        while ((n = is.read(b)) != -1) {
            baos.write(b, 0, n);
        }
        is.close();
        b = baos.toByteArray();
        baos.toByteArray();
        return new String(b);
    }

    public static String post(String url, String data) throws Exception {
        URL u = new URL(url);
        HttpURLConnection con = (HttpURLConnection) u.openConnection();
        con.setRequestMethod("POST");
        con.setRequestProperty("Content-Type", "application/json");
        con.setRequestProperty("Accept", "application/json");
        con.setDoOutput(true);

        // Send Request Data
        try (OutputStream os = con.getOutputStream()) {
            System.out.println("🔹 Sending JSON: " + data);
            os.write(data.getBytes("UTF-8"));
            os.flush();
        }

        // Get Response Code
        int responseCode = con.getResponseCode();
        System.out.println("🔹 Response Code: " + responseCode);

        // Choose correct InputStream (ErrorStream for failure)
        InputStream is;
        if (responseCode >= 200 && responseCode < 300) {
            is = con.getInputStream(); // Success response
        } else {
            is = con.getErrorStream(); // Error response
            System.out.println("🔴 Server Error Response: " + convertStreamToString(is));
            return "error: " + responseCode;
        }

        // Read Response
        String response = convertStreamToString(is);
        System.out.println("✅ Response: " + response);
        return response;
    }

    // Helper Method to Convert Stream to String
    private static String convertStreamToString(InputStream is) throws Exception {
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        byte[] buffer = new byte[10240];
        int length;
        while ((length = is.read(buffer)) != -1) {
            baos.write(buffer, 0, length);
        }
        return baos.toString("UTF-8");
    }
}



