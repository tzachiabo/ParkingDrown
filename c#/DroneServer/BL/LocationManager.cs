﻿using DroneServer.BL.Missions;
using DroneServer.SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DroneServer.BL
{
    class LocationManager
    {
        private static LocationManager instance = null;
        private static Timer aTimer = null;
        private static Parking parking;
        private static Boolean is_location_verification_enabled;

        private LocationManager(Parking p)
        {
            is_location_verification_enabled = Boolean.Parse(Configuration.getInstance().get("enable_location_manager_verification"));
            double timer_interval = Double.Parse(Configuration.getInstance().get("getLocationInterval"));

            Logger.getInstance().debug("start get location timer with interval " + timer_interval);

            aTimer = new Timer(timer_interval);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            parking = p;
        }

        public static void init(Parking p)
        {
            if (instance == null)
            {
                instance = new LocationManager(p);
            }
        }

        public static void shutDown()
        {
            if (instance != null)
                instance.stop();
        }

        private void stop()
        {
            Logger.getInstance().warn("location manager has stopped");
            aTimer.Stop();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            GetLocation mission = new GetLocation();
            mission.register_to_notification(update_location);
            Logger.getInstance().debug("send get location to drone");
            if (Comm.CommManager.getInstance().isSocketInitiated)
                mission.execute();
            else
                Logger.getInstance().error("Location manager want to get location however the drone is not connected yet");
        }

        private static void update_location(Response response)
        {
            Point p = (Point)response.Data;
            Logger.getInstance().debug("update map location with this params :" + p.lat + " " + p.lng);
            BLManagger.getInstance().setLocation(p.lat, p.lng);
            
            if (BLManagger.getInstance().getSafeZone() && is_location_verification_enabled)
                Assertions.verify(validateLocation(p), "The drone is running away!");
        }

        private static bool validateLocation(Point position)
        {
            Logger.getInstance().debug("start validating location");
            Point tl = new Point(parking.border[0].lng, parking.border[0].lat);
            Point br = new Point(parking.border[0].lng, parking.border[0].lat);

            for (int i = 1; i < parking.border.Count; i++)//axis grows right and down
            {
                if (parking.border[i].lng > br.lng)
                    br.lng = parking.border[i].lng;
                else if (parking.border[i].lng < tl.lng)
                    tl.lng = parking.border[i].lng;
                if (parking.border[i].lat > br.lat)
                    br.lat = parking.border[i].lat;
                else if (parking.border[i].lat < tl.lat)
                    tl.lat = parking.border[i].lat;
            }

            if (tl.lng<=position.lng && br.lng >= position.lng && tl.lat <= position.lat && br.lat >= position.lat)
                return true;

            Logger.getInstance().error("drone cross the border and got to mexico");
            BLManagger.getInstance().stop();

            Logger.getInstance().debug("validating location return false");
            return false;
        }


    }
}
