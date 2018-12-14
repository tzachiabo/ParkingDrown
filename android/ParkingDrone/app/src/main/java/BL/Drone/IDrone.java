package BL.Drone;

import SharedClasses.Promise;
import dji.common.flightcontroller.LocationCoordinate3D;

public interface IDrone {
    boolean isInitiated();
    void initAircraft();
    void takeOff(final Promise p);
    void moveByGPS(double x, double y, float z, final Promise p);
    void stopMoveByGPS();
    void confirmLanding(final Promise cb);
    void goHome(final Promise cb);
    void stopGoHome();
    LocationCoordinate3D getDroneStatus();
}
