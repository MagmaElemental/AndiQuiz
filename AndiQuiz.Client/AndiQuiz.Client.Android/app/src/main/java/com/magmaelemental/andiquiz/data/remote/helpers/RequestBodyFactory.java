package com.magmaelemental.andiquiz.data.remote.helpers;

public class RequestBodyFactory {
    public String CreateAccessTokenBody(String username, String password) {
        String body = "grant_type=password&username=" + username + "&password=" + password;
        return body;
    }

    public String CreateRegisterBody(String username, String firstName, String lastName, String email, String password, String confirmPassword) {
        String registerBody = "{'UserName':'" + username + "'," +
                "'FirstName':'" + firstName + "'," +
                "'LastName':'" + lastName + "'," +
                "'Email':'" + email + "'," +
                "'Password':'" + password + "'," +
                "'ConfirmPassword':'" + confirmPassword + "'}";

        return registerBody;
    }
}
