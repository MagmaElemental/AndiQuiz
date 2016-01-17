package com.magmaelemental.andiquiz;

import android.content.Intent;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

import com.magmaelemental.andiquiz.fragments.Q1Fragment;
import com.magmaelemental.andiquiz.fragments.Q2Fragment;
import com.magmaelemental.andiquiz.fragments.Q3Fragment;
import com.magmaelemental.andiquiz.fragments.SubmitQuizFragment;

public class QuizQuistionsActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_quiz_quistions);

        ViewPager vp = (ViewPager)findViewById(R.id.viewPager);

        QuizQuistionsAdapter adapter = new QuizQuistionsAdapter(getSupportFragmentManager());
        vp.setAdapter(adapter);

    }

    public class QuizQuistionsAdapter extends FragmentPagerAdapter {

        public QuizQuistionsAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int position) {

            switch (position) {
                case 0:
                    return new Q1Fragment();
                case 1:
                    return new Q2Fragment();
                case 2:
                    return new Q3Fragment();
                case 3:
                    return new SubmitQuizFragment();
                default:
                    return null;
            }
        }

        @Override
        public int getCount() {
            return 4;
        }
    }

    public void goToProfile(View view) {
        Intent moveNext = new Intent(this, ProfileActivity.class);
        startActivity(moveNext);
    }
}
