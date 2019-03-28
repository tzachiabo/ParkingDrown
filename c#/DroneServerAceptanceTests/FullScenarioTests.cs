﻿using System;
using System.Collections.Generic;
using DroneServer.BL;
using DroneServer.SharedClasses;
using DroneServerIntegration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DroneServerAceptanceTests
{
    [TestClass]
    public class FullScenarioTests
    {
        [TestMethod]
        public void NoCar()
        {
            DroneSimulator drone = new DroneSimulator();
            drone.start_drone("drone.camera.images_path=../c#/DroneServerAceptanceTests/BasePhotoImages drone.camera.base_photo_location=3.JPG");
            BLManagger bl = BLManagger.getInstance();
            List<Parking> parkings = bl.DBGetAllParkings();

            Parking park = parkings[0];

            MissionWraper mission = bl.startMission(park);

            Assert.IsTrue(mission.Wait(60 * 5));

            int num_of_scaned_car = (int)mission.m_res.Data;
            Assert.AreEqual(num_of_scaned_car, 0);

            drone.close_drone();
        }

        [TestMethod]
        public void FewCar()
        {
            DroneSimulator drone = new DroneSimulator();
            drone.start_drone("drone.camera.images_path=../c#/DroneServerAceptanceTests/BasePhotoImages drone.camera.base_photo_location=1.JPG");
            BLManagger bl = BLManagger.getInstance();
            List<Parking> parkings = bl.DBGetAllParkings();

            Parking park = parkings[0];

            MissionWraper mission = bl.startMission(park);

            Assert.IsTrue(mission.Wait(60 * 5));

            int num_of_scaned_car = (int)mission.m_res.Data;
            Assert.AreEqual(num_of_scaned_car, 2);

            drone.close_drone();
        }

    }
}
