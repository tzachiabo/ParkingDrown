package BL.missions;
import java.util.TimerTask;

import SharedClasses.Config;
import BL.SuperTimer;
import SharedClasses.Assertions;
import SharedClasses.Direction;
import SharedClasses.Logger;
import dji.common.error.DJIError;
import dji.common.flightcontroller.virtualstick.FlightControlData;
import dji.common.util.CommonCallbacks;
import dji.sdk.products.Aircraft;
import dji.sdk.sdkmanager.DJISDKManager;

public class MoveMission extends Mission {

    private Direction direction;
    private double distance;
    private SuperTimer st;

    public MoveMission(int index, Direction direction, double distance){
        super("move", index);
        this.direction=direction;
        this.distance=distance;
    }

    @Override
    public void start() {


        final Aircraft aircraft = (Aircraft) DJISDKManager.getInstance().getProduct();

        long totalTime = ((long)distance/(long)Config.BASE_SPEED) * 1000;
        Logger.debug("start-move-mission "+"distance is "+distance+" totalTime is "+totalTime);
        st = new SuperTimer(new TimerTask() {
            @Override
            public void run() {
                FlightControlData fcd = getFCB();

                aircraft.getFlightController().sendVirtualStickFlightControlData(fcd, new CommonCallbacks.CompletionCallback() {
                    @Override
                    public void onResult(DJIError djiError) {
                        if(djiError != null) {
                            Logger.error("after move djierror is " + djiError.toString());
                            Assertions.verify(false, "failed to move drone");
                        }
                    }
                });
            }
        },this, Config.MOVMENT_BASE_INTERVAL, totalTime);
        st.schedule();
    }

    @Override
    public void stop() {
        if (!isMissionCompleted) {
            st.cancel();
            Logger.warn("move mission number " + getIndex() + " has stop");
        }
    }

    @Override
    public String encode() {
        return getName() +" "+ getIndex() + " " + "Done";
    }

    private FlightControlData getFCB(){
        FlightControlData fcd = null;
        switch (direction){
            case forward:
                fcd = new FlightControlData(0,Config.BASE_SPEED,0,0);
                break;
            case right:
                fcd = new FlightControlData(Config.BASE_SPEED,0,0,0);
                break;
            case left:
                fcd = new FlightControlData(-Config.BASE_SPEED,0,0,0);
                break;
            case backward:
                fcd = new FlightControlData(0,-Config.BASE_SPEED,0,0);
                break;
            case up:
                fcd = new FlightControlData(0,0,0,Config.BASE_SPEED);
                break;
            case down:
                fcd = new FlightControlData(0,0,0,-Config.BASE_SPEED);
                break;
            default:
                Logger.error("Couldnt parse move direction");
                Assertions.verify(false, "getFCB is in unexpected flow");
                break;
        }

        return fcd;
    }

}


