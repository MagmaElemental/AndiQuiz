package com.magmaelemental.andiquiz.data.remote;

import android.os.AsyncTask;
import android.util.Log;

import com.magmaelemental.andiquiz.data.remote.helpers.DataParser;

import java.io.IOException;

import okhttp3.HttpUrl;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;

public class FetchDataTask extends AsyncTask<String, Void, String> {

    public interface TaskDoneListener {
        void onDone(String result);
    }

    private TaskDoneListener listener;

    private static final String LOG_TAG = FetchDataTask.class.getSimpleName();

    private static final String BASE_URL = "http://andiquiz.apphb.com/";
    private static final String CONTENT_TYPE_QUERY = "application/x-www-form-urlencoded";
    private static final String CONTENT_TYPE_JSON = "application/json; charset=utf-8";
    public static final MediaType MEDIA_TYPE_QUERY = MediaType.parse(CONTENT_TYPE_QUERY);
    public static final MediaType MEDIA_TYPE_JSON = MediaType.parse(CONTENT_TYPE_JSON);
    private static final DataParser DATA_PARSER = new DataParser();

    public FetchDataTask(TaskDoneListener listener) {
        super();
        this.listener = listener;
    }

    @Override
    protected String doInBackground(String... params) {
        String stringUrl = BASE_URL + params[0];
        Request request;

        if (params[0] == "token") {
            String username = params[1];
            String password = params[2];
            String body = "grant_type=password&password="+password+"&username="+username;
            request = this.GetRequestForPostWithBody(stringUrl, MEDIA_TYPE_QUERY, body, "");
        } else {
            if (params[1] == "GET") { // URL, METHOD, AUTHORIZATION, PAGE, PAGESIZE
                String authorizationToken = params[2];
                String page = params[3];
                String pageSize = params[4];
                request = this.GetRequestForGet(params[0], authorizationToken, page, pageSize);
            } else { // URL, METHOD, CONTENT_TYPE("json" or "query"), BODY, AUTHORIZATION
                String authorizationToken = params[4];
                String requestBodyString = params[3];
                MediaType mediaType;
                if (params[2] == "json") {
                    mediaType = MEDIA_TYPE_JSON;
                } else {
                    mediaType = MEDIA_TYPE_QUERY;
                }

                request = this.GetRequestForPostWithBody(stringUrl, mediaType, requestBodyString, authorizationToken);
            }
        }

        OkHttpClient client = new OkHttpClient();
        String result = null;
        try {
            Response response = client.newCall(request).execute();
            result = response.body().string();
        } catch (IOException e) {
            Log.e(LOG_TAG, "Error " + e.getMessage(), e);
            return null;
        }

        return result;
    }

    private Request GetRequestForGet(String path, String authorizationToken, String page, String pageSize) {
        HttpUrl url = new HttpUrl.Builder()
                .scheme("http")
                .host("andiquiz.apphb.com")
                .addPathSegment(path)
                .addQueryParameter("page", page)
                .addQueryParameter("pageSize", pageSize)
                .build();

        Request request = new Request.Builder()
                .url(url)
                .get()
                .addHeader("Authorization", "Bearer " + authorizationToken)
                .build();

        return request;
    }

    private Request GetRequestForPostWithBody(String url, MediaType mediaType, String body, String authorizationToken) {
        RequestBody requestBody = RequestBody.create(mediaType, body);
        Request request = new Request.Builder()
                .url(url)
                .post(requestBody)
                .addHeader("Authorization", "Bearer " + authorizationToken)
                .build();

        return request;
    }

    @Override
    protected void onPostExecute(String objAsJsonString) {
        this.listener.onDone(objAsJsonString);
    }

    //    private Request GetRequestForToken(String username, String password) {
//        RequestBody requestBody = RequestBody.create(MEDIA_TYPE_QUERY, "grant_type=password&password="+password+"&username="+username);
//        Request request = new Request.Builder()
//                .url(BASE_URL + "token")
//                .post(requestBody)
//                .addHeader("Content-Type", CONTENT_TYPE_QUERY)
//                .build();
//
//        return request;
//        HttpUrl url = new HttpUrl.Builder()
//                .scheme("http")
//                .host("andiquiz.apphb.com")
//                .addPathSegment("token")
//                .addQueryParameter("username", username)
//                .addQueryParameter("password", password)
//                .addQueryParameter("grant_type", "password")
//                .build();

//        Request request = new Request.Builder()
//                .url(url)
//                .get()
//                .addHeader("Content-Type", CONTENT_TYPE_QUERY)
//                .build();
//
//        return request;
//    }
}
