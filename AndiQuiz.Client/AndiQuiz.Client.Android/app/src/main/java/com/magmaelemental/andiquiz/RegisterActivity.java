package com.magmaelemental.andiquiz;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.annotation.TargetApi;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;

import android.os.Build;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.magmaelemental.andiquiz.data.local.QuizDbAdapter;
import com.magmaelemental.andiquiz.data.remote.FetchDataTask;
import com.magmaelemental.andiquiz.data.remote.helpers.DataParser;
import com.magmaelemental.andiquiz.data.remote.helpers.RequestBodyFactory;
import com.magmaelemental.andiquiz.data.remote.models.UserPersonalDetails;

import org.json.JSONException;
import org.w3c.dom.Text;

import java.util.Objects;

public class RegisterActivity extends AppCompatActivity {

    /**
     * Set up the {@link android.app.ActionBar}, if the API is available.
     */
    @TargetApi(Build.VERSION_CODES.HONEYCOMB)
    private void setupActionBar() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB) {
            // Show the Up button in the action bar.
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        }
    }

    private FetchDataTask mRegisterTask = null;

    // UI references.
    private TextView mUsernameTextView;
    private TextView mFirstNameTextView;
    private TextView mLastNameTextView;
    private TextView mEmailTextView;
    private TextView mPasswordTextView;
    private TextView mConfirmPasswordTextView;

    private View mProgressView;
    private View mRegisterFormView;

    private final RequestBodyFactory rqBodyFactory = new RequestBodyFactory();
    private Button mRegisterButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        setupActionBar();

        Button mRegisterButton = (Button) findViewById(R.id.register_button);
        mRegisterButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                attemptRegister();
            }
        });

        mUsernameTextView = (TextView) findViewById(R.id.username);
        mFirstNameTextView = (TextView) findViewById(R.id.firstName);
        mLastNameTextView = (TextView) findViewById(R.id.lastName);
        mEmailTextView = (TextView) findViewById(R.id.email);
        mPasswordTextView = (TextView) findViewById(R.id.password);
        mConfirmPasswordTextView = (TextView) findViewById(R.id.confirmPassword);

        mRegisterFormView = findViewById(R.id.login_form);
        mProgressView = findViewById(R.id.login_progress);
        mRegisterButton = (Button) findViewById(R.id.register_button);
        mRegisterButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                attemptRegister();
            }
        });
    }

    private void attemptRegister() {
        if (mRegisterTask != null) {
            return;
        }

        // Reset errors.
        mUsernameTextView.setError(null);
        mFirstNameTextView.setError(null);
        mLastNameTextView.setError(null);
        mEmailTextView.setError(null);
        mPasswordTextView.setError(null);
        mConfirmPasswordTextView.setError(null);

        // Store values at the time of the login attempt.
        String username = mUsernameTextView.getText().toString();
        String firstName = mFirstNameTextView.getText().toString();
        String lastName = mLastNameTextView.getText().toString();
        String email = mEmailTextView.getText().toString();
        String password = mPasswordTextView.getText().toString();
        String confirmPassword = mConfirmPasswordTextView.getText().toString();

        boolean cancel = false;
        View focusView = null;

        // Check for a valid password, if the user entered one.
        if (!TextUtils.isEmpty(username) && !isNameValid(username, 6)) {
            mUsernameTextView.setError(getString(R.string.error_invalid_username));
            focusView = mUsernameTextView;
            cancel = true;
        }

        if (!TextUtils.isEmpty(firstName) && !isNameValid(firstName, 3)) {
            mFirstNameTextView.setError(getString(R.string.error_invalid_name));
            focusView = mFirstNameTextView;
            cancel = true;
        }

        if (!TextUtils.isEmpty(lastName) && !isNameValid(lastName, 3)) {
            mLastNameTextView.setError(getString(R.string.error_invalid_name));
            focusView = mLastNameTextView;
            cancel = true;
        }

        if (!TextUtils.isEmpty(password) && !isPasswordValid(password)) {
            mPasswordTextView.setError(getString(R.string.error_invalid_password));
            focusView = mPasswordTextView;
            cancel = true;
        }

        if (!TextUtils.isEmpty(password) && !isPasswordValid(password)) {
            mConfirmPasswordTextView.setError(getString(R.string.error_invalid_password));
            focusView = mConfirmPasswordTextView;
            cancel = true;
        }

        if (!password.equals(confirmPassword)) {
            mConfirmPasswordTextView.setError(getString(R.string.error_passwords_dont_match));
            focusView = mConfirmPasswordTextView;
            cancel = true;
        }

        // Check for a valid email address.
        if (TextUtils.isEmpty(email)) {
            mEmailTextView.setError(getString(R.string.error_field_required));
            focusView = mEmailTextView;
            cancel = true;
        } else if (!isEmailValid(email)) {
            mEmailTextView.setError(getString(R.string.error_invalid_email));
            focusView = mEmailTextView;
            cancel = true;
        }

        if (cancel) {
            focusView.requestFocus();
        } else {
            showProgress(true);
            mRegisterTask = new FetchDataTask(new FetchDataTask.TaskDoneListener() {
                @Override
                public void onDone(String result) {
                    if (result != null && !Objects.equals(result, new String(""))) {
                        Toast.makeText(RegisterActivity.this, getString(R.string.error_app_crash), Toast.LENGTH_SHORT).show();
                    } else {
                        Toast.makeText(RegisterActivity.this, getString(R.string.success_user_register), Toast.LENGTH_LONG).show();
                    }

                    showProgress(false);
                    moveToLogin(mRegisterFormView);

                    mRegisterTask = null;
                    showProgress(false);
                    finish();
                }
            });

            String requestBody = rqBodyFactory.CreateRegisterBody(username, firstName, lastName, email, password, confirmPassword);
            mRegisterTask.execute("api/account/register", "POST", "JSON", requestBody, "");
        }
    }

    private boolean isNameValid(String name, Integer minLength) {
        return name.length() >= minLength;
    }

    private boolean isEmailValid(String email) {
        return email.contains("@");
    }

    private boolean isPasswordValid(String password) {
        return password.length() >= 6;
    }

    public void moveToLogin(View view) {
        Intent intent = new Intent(this, LoginActivity.class);
        startActivity(intent);
    }

    @TargetApi(Build.VERSION_CODES.HONEYCOMB_MR2)
    public void showProgress(final boolean show) {
        // On Honeycomb MR2 we have the ViewPropertyAnimator APIs, which allow
        // for very easy animations. If available, use these APIs to fade-in
        // the progress spinner.
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB_MR2) {
            int shortAnimTime = RegisterActivity.this.getResources().getInteger(android.R.integer.config_shortAnimTime);

            mRegisterFormView.setVisibility(show ? View.GONE : View.VISIBLE);
            mRegisterFormView.animate().setDuration(shortAnimTime).alpha(
                    show ? 0 : 1).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    mRegisterFormView.setVisibility(show ? View.GONE : View.VISIBLE);
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
            mRegisterFormView.setVisibility(show ? View.GONE : View.VISIBLE);
        }
    }
}

