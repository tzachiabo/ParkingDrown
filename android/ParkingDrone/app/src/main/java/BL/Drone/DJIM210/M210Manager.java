package BL.Drone.DJIM210;

import BL.Drone.IDrone;
import SharedClasses.Assertions;
import SharedClasses.Promise;
import dji.common.flightcontroller.LocationCoordinate3D;
import dji.sdk.products.Aircraft;
import dji.sdk.sdkmanager.DJISDKManager;

public class M210Manager implements IDrone{

    private Aircraft m_aircraft;
    private ControllerManager m_controller;
    private MissionControlManager m_mission_control;
    private CameraManager m_camera_manager;

    private static M210Manager instance;

    private M210Manager(){ }

    public static synchronized M210Manager getInstance(){
        if (instance == null){
            instance = new M210Manager();
        }
        return instance;
    }

    public void initAircraft(){
        m_aircraft = (Aircraft) DJISDKManager.getInstance().getProduct();
        Assertions.verify(m_aircraft != null,"Aircraft is null when constracting M210Manager");

        m_controller = new ControllerManager(m_aircraft);
        m_mission_control = new MissionControlManager();
        m_camera_manager = new CameraManager(m_aircraft.getCameras());
    }

    @Override
    public boolean isInitiated() {
        return m_aircraft != null &&
                m_controller != null && m_controller.isInitiated() &&
                m_camera_manager != null && m_camera_manager.isInitiated();
    }

    @Override
    public void takeOff(final Promise p) {
        m_controller.takeOff(p);
    }

    @Override
    public void moveByGPS(double x, double y, float z, Promise p) {
        m_mission_control.moveByGPS(x, y, z, p);
    }

    public void stopMoveByGPS(){m_mission_control.stopMoveByGPS();}

    public void confirmLanding(final Promise p){
        m_controller.confirmLanding(p);
    }

    public void goHome(final Promise p){
        m_controller.goHome(p);
    }

    public void stopGoHome(){ m_controller.stopGoHome(); }

    @Override
    public LocationCoordinate3D getDroneStatus() {
        return m_controller.getDroneStatus();
    }




}
