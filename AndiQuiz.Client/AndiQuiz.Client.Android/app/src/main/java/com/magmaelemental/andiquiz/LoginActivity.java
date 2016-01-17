package com.magmaelemental.andiquiz;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.annotation.TargetApi;
import android.content.Intent;
import android.os.Build;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;

import android.os.Bundle;
import android.text.TextUtils;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.EditorInfo;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.magmaelemental.andiquiz.data.local.QuizDbAdapter;
import com.magmaelemental.andiquiz.data.local.UserInfo;
import com.magmaelemental.andiquiz.data.remote.FetchDataTask;
import com.magmaelemental.andiquiz.data.remote.helpers.DataParser;
import com.magmaelemental.andiquiz.data.remote.models.AccessToken;
import com.magmaelemental.andiquiz.data.remote.models.UserPersonalDetails;

import org.json.JSONException;

import java.util.Calendar;
import java.util.Date;

public class LoginActivity extends AppCompatActivity {

    private FetchDataTask mAuthTask = null;

    // UI references.
    private AutoCompleteTextView mUsernameView;
    private EditText mPasswordView;
    private View mProgressView;
    private View mLoginFormView;

    private static final DataParser dataParser = new DataParser();
    private final QuizDbAdapter dbAdapter = new QuizDbAdapter(this);
    private Button registerButton;
    private AccessToken accessToken;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        UserInfo lastUserInfo = dbAdapter.getLastDataEntry();
        // check if we should update his token
        if (lastUserInfo != null && lastUserInfo.getIsLoggedIn()) {
            Date todaysDate = new Date(System.currentTimeMillis());

            // removing from todaysDate 1 Day
            Calendar cal = Calendar.getInstance();
            cal.setTime(todaysDate);
            cal.set(Calendar.HOUR_OF_DAY, 0);
            cal.set(Calendar.MINUTE, 0);
            cal.set(Calendar.SECOND, 0);
            cal.set(Calendar.MILLISECOND, 0);
            long time = cal.getTimeInMillis();

            // user is logged in and token is valid
            if (lastUserInfo.getTokenExpirationDate().getTime() > time) {
                Intent mainIntent = new Intent(LoginActivity.this, MainActivity.class);
                startActivity(mainIntent);
                finish();
            }
        }

        mUsernameView = (AutoCompleteTextView) findViewById(R.id.username);

        registerButton = (Button) findViewById(R.id.register_button);
        registerButton.setOnClickListener(registerButtonListener);

        mPasswordView = (EditText) findViewById(R.id.password);
        mPasswordView.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView textView, int id, KeyEvent keyEvent) {
                if (id == R.id.login || id == EditorInfo.IME_NULL) {
                    attemptLogin();
                    return true;
                }
                return false;
            }
        });

        Button mEmailSignInButton = (Button) findViewById(R.id.log_in_button);
        mEmailSignInButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                attemptLogin();
            }
        });

        mLoginFormView = findViewById(R.id.login_form);
        mProgressView = findViewById(R.id.login_progress);
    }

    private void attemptLogin() {
        if (mAuthTask != null) {
            return;
        }

        mUsernameView.setError(null);
        mPasswordView.setError(null);

        final String username = mUsernameView.getText().toString();
        String password = mPasswordView.getText().toString();

        boolean cancel = false;
        View focusView = null;

        // Check for a valid password, if the user entered one.
        if (!TextUtils.isEmpty(username) && !isUsernameValid(username)) {
            mUsernameView.setError(getString(R.string.error_invalid_username));
            focusView = mUsernameView;
            cancel = true;
        }

        if (!TextUtils.isEmpty(password) && !isPasswordValid(password)) {
            mPasswordView.setError(getString(R.string.error_invalid_password));
            focusView = mPasswordView;
            cancel = true;
        }

        if (cancel) {
            focusView.requestFocus();
        } else {
            showProgress(true);
            mAuthTask = new FetchDataTask(new FetchDataTask.TaskDoneListener() {
                @Override
                public void onDone(String accessTokenJsonString) {
                    try {
                        accessToken = dataParser.getAccessTokenFromJson(accessTokenJsonString);
                        FetchDataTask userDetailsTask = new FetchDataTask(new FetchDataTask.TaskDoneListener() {
                            @Override
                            public void onDone(String userPersonalDetailsJsonString) {
                                UserPersonalDetails personalDetails = null;
                                try {
                                    personalDetails = dataParser.getUserPersonalDetailsFromJson(userPersonalDetailsJsonString);
                                    dbAdapter.insertData(personalDetails.getFirstName(),
                                            personalDetails.getLastName(),
                                            username,
                                            personalDetails.getCorrectAnswers(),
                                            personalDetails.getTotalAnswers(),
                                            accessToken.getToken(),
                                            accessToken.getExpiresInSeconds(),
                                            true);
                                } catch (JSONException e) {
                                    Toast.makeText(LoginActivity.this, getString(R.string.error_app_crash), Toast.LENGTH_SHORT).show();
                                }

                                showProgress(false);
                                moveToMain(mLoginFormView);
                                finish();
                            }
                        });

                        userDetailsTask.execute("api/users/" + username, "GET", accessToken.getToken(), "", "");
                    } catch (JSONException e) {
                        Toast.makeText(LoginActivity.this, getString(R.string.error_wrong_input), Toast.LENGTH_LONG).show();
                    }

                    showProgress(false);
                }
            });

            mAuthTask.execute("token", username, password);
        }
    }

    private boolean isUsernameValid(String username) {
        //TODO: Replace this with your own logic
        return username.length() >= 6;
    }

    private boolean isPasswordValid(String password) {
        //TODO: Replace this with your own logic
        return password.length() >= 6;
    }

    public void moveToMain(View view) {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    private View.OnClickListener registerButtonListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Intent intent = new Intent(v.getContext(), RegisterActivity.class);
            startActivity(intent);
        }
    };

    @TargetApi(Build.VERSION_CODES.HONEYCOMB_MR2)
    public void showProgress(final boolean show) {
        // On Honeycomb MR2 we have the ViewPropertyAnimator APIs, which allow
        // for very easy animations. If available, use these APIs to fade-in
        // the progress spinner.
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB_MR2) {
            int shortAnimTime = LoginActivity.this.getResources().getInteger(android.R.integer.config_shortAnimTime);

            mLoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);
            mLoginFormView.animate().setDuration(shortAnimTime).alpha(
                    show ? 0 : 1).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    mLoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);
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
            mLoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);
        }
    }

    private Boolean exit = false;

    @Override
    public void onBackPressed() {
        if (exit) {
            finish();
        } else {
            Toast.makeText(this, "Press Back again to Exit.",
                    Toast.LENGTH_SHORT).show();
            exit = true;
            new Handler().postDelayed(new Runnable() {
                @Override
                public void run() {
                    exit = false;
                }
            }, 3 * 1000);
        }
    }
}

