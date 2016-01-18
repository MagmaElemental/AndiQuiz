package com.magmaelemental.andiquiz;

import android.content.Intent;
import android.graphics.Bitmap;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.magmaelemental.andiquiz.data.local.QuizDbAdapter;
import com.magmaelemental.andiquiz.data.local.UserInfo;

public class ProfileActivity extends AppCompatActivity {

    int myRequestCode = 1234;
    ImageView imageView;
    TextView tvFirstName;
    TextView tvLastName;
    private static QuizDbAdapter dbAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);

        dbAdapter = new QuizDbAdapter(this);

        UserInfo lastUserInfo = dbAdapter.getLastDataEntry();

        imageView = (ImageView) this.findViewById(R.id.photo_taken);

        tvFirstName = (TextView) this.findViewById(R.id.tvFirstName);
        tvFirstName.setText(lastUserInfo.getFirstName());

        tvLastName = (TextView) this.findViewById(R.id.tvLastName);
        tvLastName.setText(lastUserInfo.getLastName());
    }

    public void moveToFindQuiz(View view) {
        Intent moveNext = new Intent(this, FindQuizActivity.class);
        startActivity(moveNext);
    }

    public void moveToQuiz(View view) {
        Intent moveNext = new Intent(this, QuizActivity.class);
        startActivity(moveNext);
    }

    public void updateImage(View view) {
        Intent takePhotoIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

        if (takePhotoIntent.resolveActivity(getPackageManager()) != null) {
            startActivityForResult(takePhotoIntent, myRequestCode);
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == myRequestCode && resultCode == RESULT_OK) {
            Bundle extras = data.getExtras();
            Bitmap imageBitmap = (Bitmap) extras.get("data");

            imageView = (ImageView) this.findViewById(R.id.photo_taken);
            imageView.setImageBitmap(imageBitmap);
        }
    }
}
