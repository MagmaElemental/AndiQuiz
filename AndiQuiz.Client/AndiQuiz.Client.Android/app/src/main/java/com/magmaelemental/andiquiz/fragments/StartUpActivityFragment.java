package com.magmaelemental.andiquiz.fragments;

import android.content.Intent;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.magmaelemental.andiquiz.LoginActivity;
import com.magmaelemental.andiquiz.MainActivity;
import com.magmaelemental.andiquiz.R;
import com.magmaelemental.andiquiz.data.local.QuizDbAdapter;
import com.magmaelemental.andiquiz.data.local.UserInfo;

import java.util.Calendar;
import java.util.Date;

public class StartUpActivityFragment extends Fragment {

    public StartUpActivityFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        QuizDbAdapter dbAdapter = new QuizDbAdapter(getActivity());
        UserInfo lastUserInfo = dbAdapter.getLastDataEntry();

        // check if we should update his token
        if (lastUserInfo != null && !lastUserInfo.getIsLoggedIn()) {
            Date todaysDate = new Date(System.currentTimeMillis());

            // removing from todaysDate 1 Day
            Calendar cal = Calendar.getInstance();
            cal.setTime(todaysDate);
            cal.set(Calendar.HOUR_OF_DAY, 0);
            cal.set(Calendar.MINUTE, 0);
            cal.set(Calendar.SECOND, 0);
            cal.set(Calendar.MILLISECOND, 0);
            long time = cal.getTimeInMillis();

            // must update token
            if (lastUserInfo.getTokenExpirationDate().getTime() < time) {

                // TODO: update token
                System.out.println("~~~~~~~~~~~~~ MUST UPDATE TOKEN");

            } else {
                Intent mainIntent = new Intent(getActivity(), MainActivity.class);
                startActivity(mainIntent);
            }
        } else {
            Intent loginIntent = new Intent(getActivity(), LoginActivity.class);
            startActivity(loginIntent);
        }

        return inflater.inflate(R.layout.fragment_start_up, container, false);
    }
}
