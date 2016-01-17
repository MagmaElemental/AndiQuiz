package com.magmaelemental.andiquiz.fragments;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.magmaelemental.andiquiz.QuizActivity;
import com.magmaelemental.andiquiz.R;

public class SubmitQuizFragment extends Fragment {
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_quiz_submit, container, false);
        return rootView;
    }


}
