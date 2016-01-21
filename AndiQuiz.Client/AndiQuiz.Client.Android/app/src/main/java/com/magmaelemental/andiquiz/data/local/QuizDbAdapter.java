package com.magmaelemental.andiquiz.data.local;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

import java.util.Calendar;
import java.util.Date;

import java.util.ArrayList;

public class QuizDbAdapter {

    private static String[] ALL_DATA_COLUMNS = {
            QuizDbHelper.FIRST_NAME,
            QuizDbHelper.LAST_NAME,
            QuizDbHelper.USERNAME,
            QuizDbHelper.CORRECT_ANSWERS,
            QuizDbHelper.TOTAL_ANSWERS,
            QuizDbHelper.TOKEN,
            QuizDbHelper.TOKEN_EXPIRATION_TIME_IN_SECONDS,
            QuizDbHelper.IS_LOGGED_IN,
            QuizDbHelper.IMAGE_PATH
    };

    QuizDbHelper helper;

    public QuizDbAdapter(Context context) {
        helper = new QuizDbHelper(context);
    }

    public long insertData(String firstName,
                           String lastName,
                           String userName,
                           Integer correctAnswers,
                           Integer totalAnswers,
                           String token,
                           Integer tokenExpirationTimeInSeconds,
                           Boolean isLoggedIn,
                           String imagePath) {
        Calendar calendar = Calendar.getInstance(); // gets a calendar using the default time zone and locale.
        calendar.add(Calendar.SECOND, tokenExpirationTimeInSeconds);
        Date date = calendar.getTime();

        SQLiteDatabase db = helper.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(QuizDbHelper.FIRST_NAME, firstName);
        contentValues.put(QuizDbHelper.LAST_NAME, lastName);
        contentValues.put(QuizDbHelper.USERNAME, userName);
        contentValues.put(QuizDbHelper.CORRECT_ANSWERS, correctAnswers);
        contentValues.put(QuizDbHelper.TOTAL_ANSWERS, totalAnswers);
        contentValues.put(QuizDbHelper.TOKEN, token);
        contentValues.put(QuizDbHelper.TOKEN_EXPIRATION_TIME_IN_SECONDS, date.getTime());
        contentValues.put(QuizDbHelper.IS_LOGGED_IN, isLoggedIn);
        contentValues.put(QuizDbHelper.IMAGE_PATH, imagePath);

        long id = db.insert(QuizDbHelper.TABLE_NAME, null, contentValues);
        return id;
    }

    public ArrayList<UserInfo> getAllData() {
        SQLiteDatabase db = helper.getWritableDatabase();

        Cursor cursor = db.query(QuizDbHelper.TABLE_NAME, ALL_DATA_COLUMNS, null, null, null, null, null);
        ArrayList<UserInfo> data = new ArrayList<UserInfo>();

        while (cursor.moveToNext()) {
            UserInfo userInfo = this.createUserInfoFromCursor(cursor);
            data.add(userInfo);
        }

        return data;
    }

    public ArrayList<UserInfo> getDataByUserName(String username) {
        SQLiteDatabase db = helper.getWritableDatabase();

        Cursor cursor = db.query(QuizDbHelper.TABLE_NAME, ALL_DATA_COLUMNS, QuizDbHelper.USERNAME + " = '" + username + "'", null, null, null, null);
        ArrayList<UserInfo> data = new ArrayList<UserInfo>();

        while (cursor.moveToNext()) {

            UserInfo userInfo = this.createUserInfoFromCursor(cursor);

            data.add(userInfo);
        }

        return data;
    }

    public UserInfo getLastDataEntry() {
        SQLiteDatabase db = helper.getWritableDatabase();
        Cursor cursor = db.query(QuizDbHelper.TABLE_NAME, ALL_DATA_COLUMNS, null, null, null, null, QuizDbHelper.UID + " DESC");
        UserInfo userInfo = null;
        if (cursor.getCount() > 0) {
            cursor.moveToNext();
            userInfo = this.createUserInfoFromCursor(cursor);
        }

        return userInfo;
    }

    private UserInfo createUserInfoFromCursor(Cursor cursor) {
        int index1 = cursor.getColumnIndex(QuizDbHelper.FIRST_NAME);
        String firstName = cursor.getString(index1);

        int index2 = cursor.getColumnIndex(QuizDbHelper.LAST_NAME);
        String lastName = cursor.getString(index2);

        int index3 = cursor.getColumnIndex(QuizDbHelper.USERNAME);
        String userName = cursor.getString(index3);

        int index4 = cursor.getColumnIndex(QuizDbHelper.CORRECT_ANSWERS);
        Integer correctAnswers = cursor.getInt(index4);

        int index5 = cursor.getColumnIndex(QuizDbHelper.TOTAL_ANSWERS);
        Integer totalAnswers = cursor.getInt(index5);

        int index6 = cursor.getColumnIndex(QuizDbHelper.TOKEN);
        String token = cursor.getString(index6);

        int index7 = cursor.getColumnIndex(QuizDbHelper.TOKEN_EXPIRATION_TIME_IN_SECONDS);
        Date tokenExpirationDate = new Date(cursor.getLong(index7));

        int index8 = cursor.getColumnIndex(QuizDbHelper.IS_LOGGED_IN);
        Boolean isLoggedIn = cursor.getInt(index8) > 0;

        int index9 = cursor.getColumnIndex(QuizDbHelper.IMAGE_PATH);
        String imagePath = cursor.getString(index9);

        return new UserInfo(firstName, lastName, userName, correctAnswers, totalAnswers, token, tokenExpirationDate, isLoggedIn, imagePath);
    }

    public void insertImagePath(String imagePath){
        SQLiteDatabase db = helper.getWritableDatabase();
        ContentValues updatePhoto = new ContentValues();
        updatePhoto.put(QuizDbHelper.IMAGE_PATH, imagePath);
        db.insert(QuizDbHelper.TABLE_NAME, null, updatePhoto);
    }

    public void createTable(){
        SQLiteDatabase db = helper.getWritableDatabase();
        helper.onCreate(db);
    }

    public String getDbName(){
        return QuizDbHelper.DATABASE_NAME;
    }

    private static class QuizDbHelper extends SQLiteOpenHelper {

        private static final int DATABASE_VERSION = 1;
        private static final String DATABASE_NAME = "AndiQuizDb123412";
        private static final String TABLE_NAME = "UserInfo";

        private static final String UID = "_id";
        private static final String FIRST_NAME = "FirstName";
        private static final String LAST_NAME = "LastName";
        private static final String USERNAME = "UserName";
        private static final String CORRECT_ANSWERS = "CorrectAnswers";
        private static final String TOTAL_ANSWERS = "TotalAnswers";
        private static final String TOKEN = "Token";
        private static final String TOKEN_EXPIRATION_TIME_IN_SECONDS = "TokenExpirationDate";
        private static final String IS_LOGGED_IN = "IsLoggedIn";
        private static final String IMAGE_PATH = null ;

        private static final String CREATE_TABLE = "CREATE TABLE " + TABLE_NAME + " (" + UID + " INTEGER PRIMARY KEY AUTOINCREMENT," +
                " " + FIRST_NAME + " NVARCHAR (100)," +
                " " + LAST_NAME + " NVARCHAR (100)," +
                " " + USERNAME + " NVARCHAR (100)," +
                " " + CORRECT_ANSWERS + " INTEGER," +
                " " + TOTAL_ANSWERS + " INTEGER," +
                " " + TOKEN + " VARCHAR (255)," +
                " " + TOKEN_EXPIRATION_TIME_IN_SECONDS + " DATETIME," +
                " " + IS_LOGGED_IN + " BOOLEAN)" +
                " " + IMAGE_PATH + " NVARCHAR (150) " ;
        private static final String DROP_TABLE = "DROP TABLE IF EXISTS " + TABLE_NAME;


        private Context context;

        public QuizDbHelper(Context context) {
            super(context, DATABASE_NAME, null, DATABASE_VERSION);
            this.context = context;
        }

        @Override
        public void onCreate(SQLiteDatabase db) {
            try {
                db.execSQL(CREATE_TABLE);
            } catch (SQLException e) {
                Toast.makeText(context, "" + e, Toast.LENGTH_SHORT).show();
            }
        }

        @Override
        public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
            try {
                db.execSQL(DROP_TABLE);
                onCreate(db);
            } catch (SQLException e) {
                Toast.makeText(context, "" + e, Toast.LENGTH_SHORT).show();
            }
        }
    }
}
