package com.example.wilckersonganda.artigocientifico;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.StatusLine;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

import java.io.ByteArrayOutputStream;
import java.io.IOException;

/**
 * Created by wilckersonganda on 08/04/16.
 */
public class WebRequestActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.web_request);

        final TextView lblElapsedTime = (TextView) findViewById(R.id.lblElapsedTime);
        Button btnWebRequest = (Button) findViewById(R.id.btnWebRequest);
        btnWebRequest.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                lblElapsedTime.setText("Requesting..");

                AsyncTask.execute(new Runnable() {
                    @Override
                    public void run() {


                        long start = System.currentTimeMillis();

                        String url = "https://api.github.com/users/xamarin/repos";

                        HttpClient httpclient = new DefaultHttpClient();
                        HttpResponse response = null;
                        try {
                            response = httpclient.execute(new HttpGet(url));

                            StatusLine statusLine = response.getStatusLine();
                            if (statusLine.getStatusCode() == HttpStatus.SC_OK) {

                                long stop = System.currentTimeMillis();
                                final float elapsedTime = (stop - start);

                                runOnUiThread(new Runnable() {
                                    @Override
                                    public void run() {
                                        lblElapsedTime.setText(String.format("Elapsed time: %.0f", elapsedTime));
                                    }
                                });

                                ByteArrayOutputStream out = new ByteArrayOutputStream();
                                response.getEntity().writeTo(out);
                                String responseString = out.toString();
                                out.close();
                                Log.d(null,responseString);
                                //..more logic
                            } else {
                                //Closes the connection.
                                response.getEntity().getContent().close();
                                throw new IOException(statusLine.getReasonPhrase());
                            }
                        } catch (IOException e) {
                            e.printStackTrace();
                        }
                    }
                });
            }
        });
    }
}