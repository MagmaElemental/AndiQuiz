package com.magmaelemental.andiquiz.data.remote;

import android.net.Uri;
import android.os.AsyncTask;
import android.util.Log;

import com.magmaelemental.andiquiz.data.remote.helpers.DataParser;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class FetchDataTask extends AsyncTask<String, Void, String> {

    public interface TaskDoneListener {
        public void onDone(String result);
    }

    private TaskDoneListener listener;

    private static final String LOG_TAG = FetchDataTask.class.getSimpleName();

    private static final String BASE_URL = "http://andiquiz.apphb.com/";
    private static final String CONTENT_TYPE = "application/json";
    private static final DataParser DATA_PARSER = new DataParser();
    private static HttpURLConnection CONNECTION = null;
    private static InputStream STREAM = null;
    private static BufferedReader READER = null;
    private static Uri URI = null;
    private static URL URL = null;
    private static StringBuffer BUFFER = null;
    private static String RESULT = null;

    private String method;
    private String token = "";
    private String username;
    private String password;

    public FetchDataTask(TaskDoneListener listener) {
        super();
        this.listener = listener;
    }

    @Override
    protected String doInBackground(String... params) {
        // METHOD, AUTH TOKEN
        if (params.length == 3) {
            this.method = params[1];
            this.token = params[2];
        } else if (params.length == 4) {
            this.method = params[1];
            this.username = params[2];
            this.password = params[3];
        }

        try {
            URI = Uri.parse(BASE_URL + params[0]).buildUpon().build();
            URL = new URL(URI.toString());
            CONNECTION = (HttpURLConnection) URL.openConnection();
            CONNECTION.setRequestMethod(method);
            if (method != "GET") {
                CONNECTION.setRequestProperty("Content-Type", CONTENT_TYPE);
            }

            if (this.token != null && this.token != "") {
                CONNECTION.setRequestProperty("Authorization", "Bearer " + this.token);
            }

            int status = CONNECTION.getResponseCode();
            STREAM = CONNECTION.getInputStream();
            BUFFER = new StringBuffer();
            if (STREAM == null) {
                // Nothing to do.
                return null;
            }

            READER = new BufferedReader(new InputStreamReader(STREAM));
            String line;
            while ((line = READER.readLine()) != null) {
                // Since it's JSON, adding a newline isn't necessary (it won't affect parsing)
                // But it does make debugging a *lot* easier if you print out the completed
                // buffer for debugging.
                BUFFER.append(line + "\n");
            }

            if (BUFFER.length() == 0) {
                // Stream was empty.  No point in parsing.
                return null;
            }

            RESULT = BUFFER.toString();
        } catch (IOException e) {
            Log.e(LOG_TAG, "Error " + e.getMessage(), e);
            // If the code didn't successfully get the weather data, there's no point in attemping
            // to parse it.
            return null;
        } finally {
            if (CONNECTION != null) {
                CONNECTION.disconnect();
            }

            if (READER != null) {
                try {
                    READER.close();
                } catch (final IOException e) {
                    Log.e(LOG_TAG, "Error closing stream", e);
                }
            }
        }

        return RESULT;
    }

    @Override
    protected void onPostExecute(String objAsJsonString) {
        this.listener.onDone(objAsJsonString);
    }
}
