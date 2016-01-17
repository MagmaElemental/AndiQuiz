package com.magmaelemental.andiquiz;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class ProfileActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);
    }

    public void moveToFindQuiz(View view) {
        Intent moveNext = new Intent(this, FindQuizActivity.class);
        startActivity(moveNext);
    }

    public void moveToQuiz(View view) {
        Intent moveNext = new Intent(this, QuizActivity.class);
        startActivity(moveNext);
    }


    public void updateImage(View view) {

    }
}
