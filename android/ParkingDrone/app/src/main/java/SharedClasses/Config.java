package SharedClasses;

public interface Config {
    float BASE_SPEED = 2;
    long MOVMENT_BASE_INTERVAL = 25;
    String DST_ADDRESS = "192.168.60.36";
    int DST_PORT = 3000;
    String MAIN_CAMERA_NAME = "Zenmuse X5S";
    String DJI_PHOTO_DIR = "DJI_ScreenShot";
    int TIME_OF_GIMBAL_MOVE = 2;//seconds
    int MAX_TIME_WAIT_FOR_LANDING = 150000;//ms
    int MAX_TIME_WAIT_FOR_TAKEOFF = 60000;//ms
    int MAX_TIME_FOR_SETP_IN_GO_TO_GPS = 60000;//ms
    double MAX_WAYPOINT_GAP_XY = 0.00050;
    double MAX_WAYPOINT_GAP_Z = 20;
    int NUM_OF_LOG_IN_BUCKET = 200;
    float BASE_ANGULAR_SPEED = 7;
    double BEARING_APRROXIMATION = 1;
    String BRIDGE_ADDRESS = "192.168.43.1";
    int HOME_LOCATION_HIGHT = 10;
    boolean DEBUG_MODE = true;
}
