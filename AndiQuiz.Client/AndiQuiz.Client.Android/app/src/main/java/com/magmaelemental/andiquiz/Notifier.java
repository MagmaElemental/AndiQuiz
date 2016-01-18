package com.magmaelemental.andiquiz;

import android.annotation.TargetApi;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.graphics.BitmapFactory;
import android.os.Build;

public class Notifier {
    private final static int PI_REQUEST_CODE = 123456789;
    private final static int NOTIFICATION_ID = 987654321;

    @TargetApi(Build.VERSION_CODES.LOLLIPOP)
    public static void pushNotification(Context context, String title, String content) {
        Intent notificationIntent = new Intent(context, MainActivity.class);
        PendingIntent contentIntent = PendingIntent.getActivity(context,
                PI_REQUEST_CODE, notificationIntent,
                PendingIntent.FLAG_CANCEL_CURRENT);

        NotificationManager nm = (NotificationManager) context
                .getSystemService(Context.NOTIFICATION_SERVICE);

        Resources res = context.getResources();
        Notification.Builder builder = new Notification.Builder(context);

        builder.setContentIntent(contentIntent)
                .setSmallIcon(R.drawable.ic_launcher_web)
                .setLargeIcon(BitmapFactory.decodeResource(res, R.drawable.ic_launcher_web))
                .setTicker("AndiQuiz")
                .setWhen(System.currentTimeMillis())
                .setAutoCancel(true)
                .setContentTitle(title)
                .setContentText(content);

        Notification n = builder.build();

        nm.notify(NOTIFICATION_ID, n);
    }
}
