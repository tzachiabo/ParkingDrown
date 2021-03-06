﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET;

using DroneServer.BL;
using DroneServer.SharedClasses;
using Point = DroneServer.SharedClasses.Point;
using DroneServer.BL.CV;

namespace DroneServer
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        BLManagger bl;
        List<Parking> parkingList = new List<Parking>();

        private void GUI_Load(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllLines("./MyTestAppender.log", new string[0]);
            }
            catch (Exception)
            {
            }

            homePanel.Location = new System.Drawing.Point(0, 0);
            missionPanel.Location = new System.Drawing.Point(0, 0);
            missionPanel.Visible = false;

            logger_home_lst.Visible = false;
            logger_mission_lst.Visible = false;
            androidLogger_home_lst.Visible = false;
            androidLogger_mission_lst.Visible = false;

            Logger.getInstance().debug("Gui Load has started");
            confige();
            timer.Start();
            bl = BLManagger.getInstance();
            //bl.registerToLogs(logger_home_lst);
            //bl.registerToLogs(logger_mission_lst);
            bl.registerToMap(map_mission_map);
            bl.registerToConnection(connected_home_lbl);
            bl.registerToConnection(connected_mission_lbl);

            initParkingList();
            initMaps();

        }

        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            bl.shutdown();
            timer.Stop();


            try
            {
                File.Copy("./MyTestAppender.log", "./logs/"+ DateTime.Today.ToString().Replace(' ','_').Replace('/', '_').Replace(':', '_') + ".txt");
            }
            catch (Exception)
            {

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //bl.updateAndroidLog(androidLogger_home_lst,androidLogger_mission_lst);
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        //home section
        private void start_home_btn_Click(object sender, EventArgs e)
        {
            if (connected_home_lbl.Text != "Connected")
            {
                MessageBox.Show("Can not run missions while drone is not 'Connected'");
                return;
            }
            else if (parkings_home_lst.SelectedIndex == -1)
            {
                MessageBox.Show("Please select parking");
                return;
            }

            homePanel.Visible = false;
            missionPanel.Visible = true;
            Parking p= parkingList[parkings_home_lst.SelectedIndex];
            
            
            map_mission_map.Position = new PointLatLng(p.lat, p.lng);
            map_mission_map.MinZoom = (int)p.minZoom;
            map_mission_map.MaxZoom = (int)p.maxZoom;
            map_mission_map.Zoom = (int)p.zoom;

            bl.startMission(p);
        }

        private void delete_home_btn_Click(object sender, EventArgs e)
        {
            if (parkings_home_lst.SelectedIndex == -1)
            {
                MessageBox.Show("Please select parking");
                return;
            }
            int index = parkings_home_lst.SelectedIndex;
            bl.DBDeleteParking(parkings_home_lst.Items[index].ToString());
            parkings_home_lst.Items.RemoveAt(index);
            parkingList.RemoveAt(index);
            
        }

        private void clear_home_btn_Click(object sender, EventArgs e)
        {
            bl.clearLogs();

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //create section
        private void map_create_map_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = map_create_map.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = map_create_map.FromLocalToLatLng(e.X, e.Y).Lng;
            GMapOverlay markerOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.green_pushpin);
            markerOverlay.Markers.Add(marker);
            map_create_map.Overlays.Add(markerOverlay);
            map_create_map.Position = new PointLatLng(map_create_map.Position.Lat, map_create_map.Position.Lng);

            points_create_lst.Items.Add(lat + " " + lng);

            clear_create_btn.Visible = true;
        }

        private void finish_create_btn_Click(object sender, EventArgs e)
        {
            double bearing;
            if (parkName_create_txt.Text == "")
            {
                MessageBox.Show("Please enter parking name");
                return;
            }
            if (points_create_lst.Items.Count<3)
            {
                MessageBox.Show("Please mark at least 3 points");
                return;
            }
            if (bl.DBExistParkingName(parkName_create_txt.Text))
            {
                MessageBox.Show("Parking name is already exist");
                return;
            }
            try
            {
                bearing = Convert.ToDouble(bearingBox.Text);
                if(bearing < 0 || bearing > 360)
                {
                    MessageBox.Show("invalid degree! must be in range 0 - 360 ");
                    return;
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Parking bearing must be a number");
                return;
            }
            
          
            List<Point> lp = new List<Point>();
            foreach (string item in points_create_lst.Items)
                lp.Add(new SharedClasses.Point(Convert.ToDouble(item.Split(' ')[1]), Convert.ToDouble(item.Split(' ')[0])));
            Parking tmp = new Parking(parkName_create_txt.Text, map_create_map.Position.Lat, map_create_map.Position.Lng, map_create_map.Zoom, map_create_map.MaxZoom, map_create_map.MinZoom,bearing, lp);

            int res = bl.validateParkingHeight(tmp);
            if (res == -1)
            {
                MessageBox.Show("Parking area is too big");
                return;
            }
            else if (res == -2)
            {
                MessageBox.Show("Parking area is too small");
                return;
            }

            if (!bl.DBAddParking(tmp))
            {
                MessageBox.Show("failed to add parking");
                return;
            }

            parkingList.Add(tmp);
            parkings_home_lst.Items.Add(parkName_create_txt.Text);
            


            //clear page and move to Home page
            parkName_create_txt.Text = "Parking name";
            points_create_lst.Items.Clear();
            map_create_map.Overlays.Clear();
            initMaps();
            tabControl.SelectedIndex = 0;
        }

        private void parkName_create_txt_Enter(object sender, EventArgs e)
        {
            parkName_create_txt.Text = "";
        }

        private void clear_create_btn_Click(object sender, EventArgs e)
        {
            map_create_map.Overlays.Clear();
            map_create_map.Position = new PointLatLng(map_create_map.Position.Lat, map_create_map.Position.Lng);

            points_create_lst.Items.Clear();
            clear_create_btn.Visible = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //mission section
        private void back_mission_btn_Click(object sender, EventArgs e)
        {
            missionPanel.Visible = false;
            homePanel.Visible = true;
        }

        private void stop_mission_btn_Click(object sender, EventArgs e)
        {

        }

        private void abort_mission_btn_Click(object sender, EventArgs e)
        {

        }

        private void end_mission_btn_Click(object sender, EventArgs e)
        {
            double lat = 31.2656169738942;
            double lng = 34.8071413572861;
            bl.setLocation(lat, lng, 0);
        }        

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //dummy section
        private void move_dummy_btn_Click(object sender, EventArgs e)
        {
            int move_amount = Convert.ToInt32(MoveAmount.Value);

            Logger.getInstance().debug("gui action to move forward distance : " + move_amount);

            BLManagger.getInstance().MoveForTest(move_amount, Direction.forward);
        }

        private void takeOff_dummy_btn_Click(object sender, EventArgs e)
        {
            BLManagger.getInstance().TakeOffForTest();
        }

        private void Landing_dummy_btn_Click(object sender, EventArgs e)
        {
            BLManagger.getInstance().StartLandingForTest();
        }

        private void goHome_dummy_btn_Click(object sender, EventArgs e)
        {
            BLManagger.getInstance().goHomeForTest();
        }

        private void moveGimbal_dummy_btn_Click(object sender, EventArgs e)
        {
            int roll = Convert.ToInt32(Roll.Value);
            int pitch = Convert.ToInt32(Pitch.Value);
            int yaw = Convert.ToInt32(Yaw.Value);
            BLManagger.getInstance().MoveGimbalTest(Gimbal.left, roll, pitch, yaw);
        }

        private void goToGPS_dummy_btn_Click(object sender, EventArgs e)
        {
            BLManagger.getInstance().GoToGpsTest();
        }

        private void takePhoto_dummy_btn_Click(object sender, EventArgs e)
        {
            BLManagger.getInstance().TakePhoto();
        }

        private void ConfirmLanding_dummy_btn_Click(object sender, EventArgs e)
        {
            BLManagger.getInstance().ConfirmLandingForTest();
        }

        private void parking_mission_dummy_btn_Click(object sender, EventArgs e)
        {
            BLManagger.getInstance().ParkingForTest();
        }

        private void Landing_dummy_btn_Click_1(object sender, EventArgs e)
        {
            BLManagger.getInstance().LandingForTest();
        }

        private void moveBackward_dummy_btn_Click(object sender, EventArgs e)
        {
            int move_amount = Convert.ToInt32(MoveAmount.Value);

            Logger.getInstance().debug("gui action to move backward distance : " + move_amount);

            BLManagger.getInstance().MoveForTest(move_amount, Direction.backward);
        }

        private void moveLeft_dummy_btn_Click(object sender, EventArgs e)
        {
            int move_amount = Convert.ToInt32(MoveAmount.Value);

            Logger.getInstance().debug("gui action to move left distance : " + move_amount);

            BLManagger.getInstance().MoveForTest(move_amount, Direction.left);
        }

        private void moveRight_dummy_btn_Click(object sender, EventArgs e)
        {
            int move_amount = Convert.ToInt32(MoveAmount.Value);

            Logger.getInstance().debug("gui action to move right distance : " + move_amount);

            BLManagger.getInstance().MoveForTest(move_amount, Direction.right);
        }

        private void moveDown_dummy_btn_Click(object sender, EventArgs e)
        {
            int move_amount = Convert.ToInt32(MoveAmount.Value);

            Logger.getInstance().debug("gui action to move down distance : " + move_amount);

            BLManagger.getInstance().MoveForTest(move_amount, Direction.down);
        }

        private void moveUp_dummy_btn_Click(object sender, EventArgs e)
        {
            int move_amount = Convert.ToInt32(MoveAmount.Value);

            Logger.getInstance().debug("gui action to move up distance : " + move_amount);

            BLManagger.getInstance().MoveForTest(move_amount, Direction.up);
        }

        private void stop_dummy_btn_Click(object sender, EventArgs e)
        {
            BLManagger.getInstance().stop();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //functions section

        public void initMaps()
        {
            double lat = 31.2646168738942;
            double lng = 34.8061412572861;
            try
            {
                map_create_map.MapProvider = GMapProviders.GoogleSatelliteMap;//GMapProviders.GoogleMap
                map_create_map.Position = new PointLatLng(lat, lng);
                map_create_map.MinZoom = 5;
                map_create_map.MaxZoom = 10000;
                map_create_map.Zoom = 18;
                map_create_map.DragButton = MouseButtons.Left;


                map_mission_map.MapProvider = GMapProviders.GoogleSatelliteMap;//GMapProviders.GoogleMap
                map_mission_map.Position = new PointLatLng(lat, lng);
                map_mission_map.MinZoom = 5;
                map_mission_map.MaxZoom = 10000;
                map_mission_map.Zoom = 18;
                map_mission_map.DragButton = MouseButtons.Left;
                map_mission_map.CanDragMap = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Cant show map, no internet connection");
            }
            
        }


        public void initParkingList()
        {
            List<Parking> tmp = bl.DBGetAllParkings();
            foreach (Parking item in tmp)
            {
                parkingList.Add(item);
                parkings_home_lst.Items.Add(item.name);
            }
        }
        public void confige()
        {
            if (Configuration.getInstance().get("debugMode")=="false")
            {
                tabControl.TabPages.Remove(dummyTab);
                back_mission_btn.Visible = false;
            }
            timer.Interval = Convert.ToInt32(Configuration.getInstance().get("log_interval"));

        }

        private void Yaw_ValueChanged(object sender, EventArgs e)
        {

        }

        private void end_mission_btn_Click_1(object sender, EventArgs e)
        {
            BLManagger.getInstance().endMission();
        }

        private void stop_mission_btn_Click_1(object sender, EventArgs e)
        {
            BLManagger.getInstance().stop();
        }

        private void abort_mission_btn_Click_1(object sender, EventArgs e)
        {
            BLManagger.getInstance().abort();
        }

        private void rotateright(object sender, EventArgs e)
        {
            int move_amount = Convert.ToInt32(MoveAmount.Value);
            BLManagger.getInstance().MoveForTest(move_amount, Direction.rtt_right);
        }

        private void rotateleft(object sender, EventArgs e)
        {
            int move_amount = Convert.ToInt32(MoveAmount.Value);
            BLManagger.getInstance().MoveForTest(move_amount, Direction.rtt_left);
        }

        private void getlocation(object sender, EventArgs e)
        {
            BLManagger.getInstance().getLocation();
        }

        private void absoultepostion(object sender, EventArgs e)
        {
            int move_amount = Convert.ToInt32(MoveAmount.Value);

            BLManagger.getInstance().absoutle_postision(move_amount);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int roll = Convert.ToInt32(Roll.Value);
            int pitch = Convert.ToInt32(Pitch.Value);
            int yaw = Convert.ToInt32(Yaw.Value);
            BLManagger.getInstance().MoveAbsoulteGimbalTest(Gimbal.left, roll, pitch, yaw);
        }

        private void map_create_map_Load(object sender, EventArgs e)
        {

        }

        private void get_height_btn_Click(object sender, EventArgs e)
        {
            BLManagger.getInstance().get_height();
        }
    }
}
