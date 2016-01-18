package com.magmaelemental.andiquiz.services;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.os.Handler;
import android.os.IBinder;
import android.widget.Toast;

import com.magmaelemental.andiquiz.Notifier;

import java.util.Timer;
import java.util.TimerTask;

public class ReminderService extends Service {
    public static final long NOTIFY_INTERVAL = 1000 * 60 * 60 * 24; // 24 hours | 30 * 1000; -> 20 seconds

    private Context context = this;

    // Run on another Thread to avoid crash
    private Handler handler = new Handler();

    // Timer handling
    private Timer timer = null;

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onCreate() {
        // Cancel if already existed
        if (timer != null) {
            timer.cancel();
        } else {
            // Recreate new
            timer = new Timer();
        }

        // Schedule task
        timer.scheduleAtFixedRate(new TimeDisplayTimerTask(), 0, NOTIFY_INTERVAL);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
    }

    class TimeDisplayTimerTask extends TimerTask {

        @Override
        public void run() {
            // run on another thread
            handler.post(new Runnable() {

                @Override
                public void run() {
                    String title = "Haven't solved a quiz soon?";
                    String text = "Come AndiQuiz awaits you!";
                    Notifier.pushNotification(context, title, text);
                }
            });
        }
    }
}