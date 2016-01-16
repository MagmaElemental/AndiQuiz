package com.magmaelemental.andiquiz.data.helpers;

public class DataBank {

    private static final String DATA_SOURCE = "http://andiquiz.apphb.com/";

    private String userAuthToken;

    public DataBank(String token) {
        this.userAuthToken = token;
    }
}
