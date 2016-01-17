package com.magmaelemental.andiquiz;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class QuizActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_quiz);
    }

    public void goToQuiz(View view) {
        Intent moveNext = new Intent(this, QuizQuistionsActivity.class);
        startActivity(moveNext);
    }


}
