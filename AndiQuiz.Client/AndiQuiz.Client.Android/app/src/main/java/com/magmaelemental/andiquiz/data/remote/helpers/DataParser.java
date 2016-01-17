package com.magmaelemental.andiquiz.data.remote.helpers;

import com.magmaelemental.andiquiz.data.remote.models.AccessToken;
import com.magmaelemental.andiquiz.data.remote.models.UserPersonalDetails;

import org.json.JSONException;
import org.json.JSONObject;

public class DataParser {

    private static final String LOG_TAG = DataParser.class.getSimpleName();

    public static AccessToken getAccessTokenFromJson(String accessTokenJsonString) throws JSONException {
        final String ACCESS_TOKEN = "access_token";
        final String EXPIRES_IN = "expires_in";
        final String USERNAME = "userName";

        System.out.println(accessTokenJsonString);
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
}