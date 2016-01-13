package com.magmaelemental.andiquiz.dataBase;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Message;
import android.widget.Toast;

/**
 * Created by JeDI on 1/12/2016.
 */

public class QuizDbAdapter {

    QuizDbHelper helper;
    public QuizDbAdapter(Context context){
        helper = new QuizDbHelper(context);
    }

    public long insertData(String userName, String token)
    {
        SQLiteDatabase db = helper.getWritableDatabase();
        ContentValues contentValues = new ContentValues();
        contentValues.put(QuizDbHelper.NAME, userName);
        contentValues.put(QuizDbHelper.TOKEN, token);
        long id = db.insert(QuizDbHelper.TABLE_NAME, null, contentValues);
        return id;
    }

    public String getAllData(){
        SQLiteDatabase db = helper.getWritableDatabase();

        String[] colums = {QuizDbHelper.UID, QuizDbHelper.NAME, QuizDbHelper.TOKEN};
        Cursor cursor = db.query(QuizDbHelper.TABLE_NAME, colums, null, null, null, null, null);
        StringBuffer buffer = new StringBuffer();

        while (cursor.moveToNext()){
            int cid = cursor.getInt(0);

            int index1 = cursor.getColumnIndex(QuizDbHelper.NAME);
            String name = cursor.getString(index1);

            int index2 = cursor.getColumnIndex(QuizDbHelper.TOKEN);
            String token = cursor.getString(index2);

            buffer.append(cid + " " + name + " " + token + "\n");
        }
        return buffer.toString();
    }

    public String getData(String name){
        SQLiteDatabase db = helper.getWritableDatabase();

        String[] colums = {QuizDbHelper.NAME, QuizDbHelper.TOKEN};
        Cursor cursor = db.query(QuizDbHelper.TABLE_NAME, colums, QuizDbHelper.NAME+" = '"+name+"'", null, null, null, null);
        StringBuffer buffer = new StringBuffer();

        while (cursor.moveToNext()){
            int index1 = cursor.getColumnIndex(QuizDbHelper.NAME);
            String userName = cursor.getString(index1);

            int index2 = cursor.getColumnIndex(QuizDbHelper.TOKEN);
            String token = cursor.getString(index2);

            buffer.append(name + " " + token + "\n");
        }
        return buffer.toString();
    }

    static class QuizDbHelper extends SQLiteOpenHelper {

        private static final String DATABASE_NAME = "quizDb";
        private static final String TABLE_NAME = "UserInfo";
        private static final int DATABASE_VERSION = 1;
        private static final String UID = "_id";
        private static final String NAME = "Name";
        private static final String TOKEN = "Token";
        private static final String CREATE_TABLE = "CREATE TABLE " + TABLE_NAME + " (" + UID + " INTEGER PRIMARY KEY AUTOINCREMENT, " + NAME + " VARCHAR (150), " + TOKEN + " VARCHAR (255));";
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
