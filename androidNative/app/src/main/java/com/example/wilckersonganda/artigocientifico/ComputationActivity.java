package com.example.wilckersonganda.artigocientifico;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import java.util.Arrays;

/**
 * Created by wilckersonganda on 08/04/16.
 */
public class ComputationActivity  extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.computation);

        final TextView lblElapsedTime = (TextView) findViewById(R.id.lblElapsedTime);
        final TextView lblResult = (TextView) findViewById(R.id.lblResult);

        Button btnWebRequest = (Button) findViewById(R.id.btnCompute);
        btnWebRequest.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                lblElapsedTime.setText("Requesting..");

                AsyncTask.execute(new Runnable() {
                    @Override
                    public void run() {

                        long start = System.currentTimeMillis();

                        //Algorithm
                        final StringBuffer result = ComputePiSpigotAlgorithm(1000);

                        long stop = System.currentTimeMillis();
                        final float elapsedTime = (stop - start);

                        runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                lblElapsedTime.setText(String.format("Elapsed time: %.0f", elapsedTime));
                                lblResult.setText(result);
                            }
                        });
                    }
                });
            }
        });
    }

    public StringBuffer ComputePiSpigotAlgorithm(int digits)
    {
        if ( digits > 54900)
        {
            throw new IllegalArgumentException("n must be <= 54900");
        }

        final StringBuffer pi = new StringBuffer(digits);
        final String[] zero = { "0", "00", "000" };
        int d = 0, e, b, g, r;
        int c = (digits / 4 + 1) * 14;
        final int[] a = new int[c];
        final int f = 10000;

        Arrays.fill(a, 20000000);

        while ((b = c -= 14) > 0)
        {
            d = e = d % f;

            while (--b > 0)
            {
                d = d * b + a[b];
                g = (b << 1) - 1;
                a[b] = (d % g) * f;
                d /= g;
            }

            r = e + d / f;

            if (r < 1000)
            {
                pi.append(zero[r > 99 ? 0 : r > 9 ? 1 : 2]);
            }
            pi.append(r);
        }
        return pi;
    }
}
