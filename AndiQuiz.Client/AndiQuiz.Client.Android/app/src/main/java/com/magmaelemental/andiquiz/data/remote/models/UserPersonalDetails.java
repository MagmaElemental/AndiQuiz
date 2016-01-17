package com.magmaelemental.andiquiz.data.remote.models;

public class UserPersonalDetails {
    private String firstName;
    private String lastName;
    private Integer correctAnswers;
    private Integer totalAnswers;

    public UserPersonalDetails(String firstName, String lastName, Integer correctAnswers, Integer totalAnswers) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.correctAnswers = correctAnswers;
        this.totalAnswers = totalAnswers;
    }

    public String getLastName() {
        return lastName;
    }

    public String getFirstName() {
        return firstName;
    }

    public Integer getCorrectAnswers() {
        return correctAnswers;
    }

    public Integer getTotalAnswers() {
        return totalAnswers;
    }
}
