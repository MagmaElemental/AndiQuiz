package com.magmaelemental.andiquiz;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;

import com.magmaelemental.andiquiz.data.local.QuizDbAdapter;
import com.magmaelemental.andiquiz.data.local.UserInfo;

public class MainActivity extends AppCompatActivity {

    private static QuizDbAdapter dbAdapter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        dbAdapter = new QuizDbAdapter(this);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_logout) {
            UserInfo lastUserInfo = dbAdapter.getLastDataEntry();
            dbAdapter.insertData(
                    lastUserInfo.getFirstName(),
                    lastUserInfo.getLastName(),
                    lastUserInfo.getUserName(),
                    lastUserInfo.getCorrectAnswers(),
                    lastUserInfo.getTotalAnswers(),
                    "",
                    0,
                    false
            );
        }

        Intent intent = new Intent(MainActivity.this, LoginActivity.class);
        startActivity(intent);
        finish();
        return super.onOptionsItemSelected(item);
    }
}
