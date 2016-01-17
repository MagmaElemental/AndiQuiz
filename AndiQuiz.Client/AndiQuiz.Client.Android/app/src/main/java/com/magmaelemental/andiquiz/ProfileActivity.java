package com.magmaelemental.andiquiz;

import android.content.Intent;
import android.graphics.Bitmap;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;

public class ProfileActivity extends AppCompatActivity {

    int myRequestCode = 1234;
    ImageView imageView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);

        imageView = (ImageView) this.findViewById(R.id.photo_taken);
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
