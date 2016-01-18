package com.magmaelemental.andiquiz.data.remote.models;

public class CategoryDetails {
    private String name;
    private String quizzes;

    public CategoryDetails(String name, String quizzes) {
        this.name = name;
        this.quizzes = quizzes;
    }

    public String getName() {
        return name;
    }

    public String getQuizzes() {
        return quizzes;
    }
}
