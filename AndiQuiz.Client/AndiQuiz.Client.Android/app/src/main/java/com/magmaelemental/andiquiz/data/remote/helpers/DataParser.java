package com.magmaelemental.andiquiz.data.remote.helpers;

import com.magmaelemental.andiquiz.data.remote.models.AccessToken;
import com.magmaelemental.andiquiz.data.remote.models.CategoryDetails;
import com.magmaelemental.andiquiz.data.remote.models.UserPersonalDetails;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class DataParser {

    private static final String LOG_TAG = DataParser.class.getSimpleName();

    public static AccessToken getAccessTokenFromJson(String accessTokenJsonString) throws JSONException {
        final String ACCESS_TOKEN = "access_token";
        final String EXPIRES_IN = "expires_in";
        final String USERNAME = "userName";

        JSONObject accessTokenJson = new JSONObject(accessTokenJsonString);
        String token = accessTokenJson.getString(ACCESS_TOKEN);
        Integer expiresIn = accessTokenJson.getInt(EXPIRES_IN);
        String username = accessTokenJson.getString(USERNAME);
        AccessToken accessToken = new AccessToken(token,expiresIn,username);

        return accessToken;
    }

    public static UserPersonalDetails getUserPersonalDetailsFromJson(String userPersonalDetailsJsonString) throws JSONException {
        final String FIRST_NAME = "FirstName";
        final String LAST_NAME = "LastName";
        final String CORRECT_ANSWERS = "CorrectAnswers";
        final String TOTAL_ANSWERS = "TotalAnswers";

        JSONObject personalDetailsJsonObj = new JSONObject(userPersonalDetailsJsonString);
        String firstName = personalDetailsJsonObj.getString(FIRST_NAME);
        String lastName = personalDetailsJsonObj.getString(LAST_NAME);
        Integer correct = personalDetailsJsonObj.getInt(CORRECT_ANSWERS);
        Integer total = personalDetailsJsonObj.getInt(TOTAL_ANSWERS);

        UserPersonalDetails personalDetails = new UserPersonalDetails(firstName,lastName,correct,total);

        return personalDetails;
    }

    public static ArrayList<CategoryDetails> GetCategoriesFromJson(String categoriesJsonObject) throws JSONException {
        JSONArray array = new JSONArray(categoriesJsonObject);
        Integer length = array.length();
        ArrayList<CategoryDetails> categories = new ArrayList<CategoryDetails>();
        for (int i = 0; i < length; i++) {
            JSONObject categoryJsonObject = array.getJSONObject(i);
            String name = categoryJsonObject.getString("Name");
            String quizzesCount = categoryJsonObject.getString("Quizzes");
            categories.add(new CategoryDetails(name, quizzesCount));
        }

        return categories;
    }
}