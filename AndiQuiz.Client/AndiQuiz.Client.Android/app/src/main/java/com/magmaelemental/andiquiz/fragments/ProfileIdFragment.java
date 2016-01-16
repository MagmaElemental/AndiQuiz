package com.magmaelemental.andiquiz.fragments;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.magmaelemental.andiquiz.R;

/**
 * Created by JeDI on 1/17/2016.
 */
public class ProfileIdFragment extends Fragment {
    public static final String TEXT = "text";
    public static final String STEP_NUMBER = "number";

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragmen_profile_id, container, false);
        Bundle args = getArguments();

//        TextView textView = (TextView) rootView.findViewById(R.id.textView);
//        textView.setText(args.getString(TEXT));

        return rootView;
    }
}
