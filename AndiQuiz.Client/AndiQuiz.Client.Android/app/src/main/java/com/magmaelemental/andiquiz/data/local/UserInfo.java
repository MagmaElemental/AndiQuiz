package com.magmaelemental.andiquiz.data.local;

import java.util.Date;

public class UserInfo {

    private String FirstName;
    private String LastName;
    private String UserName;
    private Integer CorrectAnswers;
    private Integer TotalAnswers;
    private String Token;
    private Date TokenExpirationDate;
    private Boolean IsLoggedIn;

    public UserInfo(String firstName, String lastName, String userName, Integer correctAnswers, Integer totalAnswers, String token, Date tokenExpirationDate, Boolean isLoggedIn) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.UserName = userName;
        this.CorrectAnswers = correctAnswers;
        this.TotalAnswers = totalAnswers;
        this.Token = token;
        this.TokenExpirationDate = tokenExpirationDate;
        this.IsLoggedIn = isLoggedIn;
    }

    public String getFirstName() {
        return FirstName;
    }

    public String getLastName() {
        return LastName;
    }

    public String getUserName() {
        return UserName;
    }

    public Integer getCorrectAnswers() {
        return CorrectAnswers;
    }

    public Integer getTotalAnswers() {
        return TotalAnswers;
    }

    public String getToken() {
        return Token;
    }

    public Date getTokenExpirationDate() {
        return TokenExpirationDate;
    }

    public Boolean getIsLoggedIn() {
        return IsLoggedIn;
    }
}
