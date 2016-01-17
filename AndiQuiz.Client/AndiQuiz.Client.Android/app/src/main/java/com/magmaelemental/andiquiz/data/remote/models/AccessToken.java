package com.magmaelemental.andiquiz.data.remote.models;

public class AccessToken {

    private String token;
    private Integer expiresInSeconds;
    private String username;

    public AccessToken(String token, Integer expiresInSeconds, String username) {
        this.token = token;
        this.expiresInSeconds = expiresInSeconds;
        this.username = username;
    }

    public String getToken() {
        return token;
    }

    public Integer getExpiresInSeconds() {
        return expiresInSeconds;
    }

    public String getUsername() {
        return username;
    }
}
