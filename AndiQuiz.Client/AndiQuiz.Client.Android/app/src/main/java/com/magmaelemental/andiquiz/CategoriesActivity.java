package com.magmaelemental.andiquiz;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.annotation.TargetApi;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.magmaelemental.andiquiz.customs.CategoryCustomArrayAdapter;
import com.magmaelemental.andiquiz.data.local.QuizDbAdapter;
import com.magmaelemental.andiquiz.data.remote.FetchDataTask;
import com.magmaelemental.andiquiz.data.remote.helpers.DataParser;
import com.magmaelemental.andiquiz.data.remote.models.CategoryDetails;

import org.json.JSONException;

import java.util.ArrayList;

public class CategoriesActivity extends AppCompatActivity {

    private static final DataParser dataParser = new DataParser();

    private View mProgressView;
    private View mCategoriesFormView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_categories);

        mCategoriesFormView = findViewById(R.id.ll_categories);
        mProgressView = findViewById(R.id.categories_progress);

        showProgress(true);
        FetchDataTask getCategoriesTask = new FetchDataTask(new FetchDataTask.TaskDoneListener() {
            @Override
            public void onDone(String result) {
                ArrayList<CategoryDetails> categories = null;
                try {
                    categories = dataParser.GetCategoriesFromJson(result);
                } catch (JSONException e) {
                    Toast.makeText(CategoriesActivity.this, "Could not load categories!", Toast.LENGTH_SHORT).show();
                }

                CategoryCustomArrayAdapter adapter = new CategoryCustomArrayAdapter(CategoriesActivity.this, categories);
                ListView lv = (ListView) findViewById(R.id.lvCategories);
                lv.setAdapter(adapter);

                showProgress(false);
            }
        });

        getCategoriesTask.execute("api/category/all", "GET", "", "1", "10");
    }

    @TargetApi(Build.VERSION_CODES.HONEYCOMB_MR2)
    public void showProgress(final boolean show) {
        // On Honeycomb MR2 we have the ViewPropertyAnimator APIs, which allow
        // for very easy animations. If available, use these APIs to fade-in
        // the progress spinner.
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB_MR2) {
            int shortAnimTime = CategoriesActivity.this.getResources().getInteger(android.R.integer.config_shortAnimTime);

            mCategoriesFormView.setVisibility(show ? View.GONE : View.VISIBLE);
            mCategoriesFormView.animate().setDuration(shortAnimTime).alpha(
                    show ? 0 : 1).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    mCategoriesFormView.setVisibility(show ? View.GONE : View.VISIBLE);
                }
            });

            mProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
            mProgressView.animate().setDuration(shortAnimTime).alpha(
                    show ? 1 : 0).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    mProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
                }
            });
        } else {
            // The ViewPropertyAnimator APIs are not available, so simply show
            // and hide the relevant UI components.
            mProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
            mCategoriesFormView.setVisibility(show ? View.GONE : View.VISIBLE);
        }
    }
}
