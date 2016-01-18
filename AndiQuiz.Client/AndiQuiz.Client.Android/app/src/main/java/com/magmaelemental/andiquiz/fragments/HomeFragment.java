package com.magmaelemental.andiquiz.fragments;


import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.magmaelemental.andiquiz.CategoriesActivity;
import com.magmaelemental.andiquiz.R;
import com.magmaelemental.andiquiz.RegisterActivity;

/**
 * A simple {@link Fragment} subclass.
 */
public class HomeFragment extends Fragment {


    public HomeFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_home, container, false);
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        Button categoriesButton = (Button) getView().findViewById(R.id.action_choose_category);
        categoriesButton.setOnClickListener(categoriesButtonListener);
    }

    private View.OnClickListener categoriesButtonListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Intent intent = new Intent(v.getContext(), CategoriesActivity.class);
            startActivity(intent);
        }
    };
}
