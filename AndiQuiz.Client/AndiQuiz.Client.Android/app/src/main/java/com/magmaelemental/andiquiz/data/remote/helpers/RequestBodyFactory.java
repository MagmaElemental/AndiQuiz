package com.magmaelemental.andiquiz.data.remote.helpers;

public class RequestBodyFactory {
    public String CreateAccessTokenBody(String username, String password) {
        String body = "grant_type=password&username=testUser&password=123456";
        return body;
    }
}
