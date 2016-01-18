package com.magmaelemental.andiquiz.customs;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.magmaelemental.andiquiz.R;
import com.magmaelemental.andiquiz.data.remote.models.CategoryDetails;

import java.util.ArrayList;

public class CategoryCustomArrayAdapter extends BaseAdapter {
    ArrayList<CategoryDetails> categoryList;
    Context c;

    public CategoryCustomArrayAdapter(Context c, ArrayList<CategoryDetails> list) {
        categoryList = list;
        this.c = c;

    }

    @Override
    public int getCount() {
        return categoryList.size();
    }

    @Override
    public Object getItem(int position) {
        return categoryList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View row = null;
        LayoutInflater inflater = (LayoutInflater) c
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        if (convertView == null) {
            row = inflater.inflate(R.layout.category_list_layout, parent,
                    false);
        } else {
            row = convertView;
        }

        CategoryDetails details = categoryList.get(position);
        TextView name = (TextView) row.findViewById(R.id.categoryName);
        name.setText(details.getName());
        TextView email = (TextView) row.findViewById(R.id.categoryQuizzes);
        email.setText(details.getQuizzes());

        return row;
    }
}
