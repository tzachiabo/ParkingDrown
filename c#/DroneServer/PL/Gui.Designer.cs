﻿namespace DroneServer
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.homeTab = new System.Windows.Forms.TabPage();
            this.start_home_btn = new System.Windows.Forms.Button();
            this.logger_home_lst = new System.Windows.Forms.ListBox();
            this.parkings_home_btn = new System.Windows.Forms.ListBox();
            this.createTab = new System.Windows.Forms.TabPage();
            this.finish_create_btn = new System.Windows.Forms.Button();
            this.parkName_create_txt = new System.Windows.Forms.TextBox();
            this.map_create_map = new System.Windows.Forms.Panel();
            this.points_create_lst = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.logger_mission_lst = new System.Windows.Forms.ListBox();
            this.connected_mission_lbl = new System.Windows.Forms.Label();
            this.abort_mission_btn = new System.Windows.Forms.Button();
            this.stop_mission_btn = new System.Windows.Forms.Button();
            this.end_mission_btn = new System.Windows.Forms.Button();
            this.map_mission_map = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MoveAmount = new System.Windows.Forms.NumericUpDown();
            this.moveDown_dummy_btn = new System.Windows.Forms.Button();
            this.moveUp_dummy_btn = new System.Windows.Forms.Button();
            this.moveRight_dummy_btn = new System.Windows.Forms.Button();
            this.moveLeft_dummy_btn = new System.Windows.Forms.Button();
            this.moveBackward_dummy_btn = new System.Windows.Forms.Button();
            this.Landing_dummy_btn = new System.Windows.Forms.Button();
            this.parking_mission_dummy_btn = new System.Windows.Forms.Button();
            this.ConfirmLanding_dummy_btn = new System.Windows.Forms.Button();
            this.moveGimbal_dummy_btn = new System.Windows.Forms.Button();
            this.goToGPS_dummy_btn = new System.Windows.Forms.Button();
            this.takePhoto_dummy_btn = new System.Windows.Forms.Button();
            this.goHome_dummy_btn = new System.Windows.Forms.Button();
            this.StartLanding_dummy_btn = new System.Windows.Forms.Button();
            this.takeOff_dummy_btn = new System.Windows.Forms.Button();
            this.moveForward_dummy_btn = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.homeTab.SuspendLayout();
            this.createTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoveAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.homeTab);
            this.tabControl.Controls.Add(this.createTab);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1575, 1000);
            this.tabControl.TabIndex = 0;
            // 
            // homeTab
            // 
            this.homeTab.Controls.Add(this.start_home_btn);
            this.homeTab.Controls.Add(this.logger_home_lst);
            this.homeTab.Controls.Add(this.parkings_home_btn);
            this.homeTab.Location = new System.Drawing.Point(4, 29);
            this.homeTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.homeTab.Name = "homeTab";
            this.homeTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.homeTab.Size = new System.Drawing.Size(1567, 967);
            this.homeTab.TabIndex = 0;
            this.homeTab.Text = "Home";
            this.homeTab.UseVisualStyleBackColor = true;
            // 
            // start_home_btn
            // 
            this.start_home_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_home_btn.Location = new System.Drawing.Point(450, 21);
            this.start_home_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.start_home_btn.Name = "start_home_btn";
            this.start_home_btn.Size = new System.Drawing.Size(250, 79);
            this.start_home_btn.TabIndex = 2;
            this.start_home_btn.Text = "Start";
            this.start_home_btn.UseVisualStyleBackColor = true;
            this.start_home_btn.Click += new System.EventHandler(this.start_home_btn_Click);
            // 
            // logger_home_lst
            // 
            this.logger_home_lst.FormattingEnabled = true;
            this.logger_home_lst.ItemHeight = 20;
            this.logger_home_lst.Location = new System.Drawing.Point(2, 128);
            this.logger_home_lst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logger_home_lst.Name = "logger_home_lst";
            this.logger_home_lst.Size = new System.Drawing.Size(1200, 764);
            this.logger_home_lst.TabIndex = 1;
            // 
            // parkings_home_btn
            // 
            this.parkings_home_btn.FormattingEnabled = true;
            this.parkings_home_btn.ItemHeight = 20;
            this.parkings_home_btn.Location = new System.Drawing.Point(1203, 8);
            this.parkings_home_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.parkings_home_btn.Name = "parkings_home_btn";
            this.parkings_home_btn.Size = new System.Drawing.Size(338, 884);
            this.parkings_home_btn.TabIndex = 0;
            // 
            // createTab
            // 
            this.createTab.Controls.Add(this.finish_create_btn);
            this.createTab.Controls.Add(this.parkName_create_txt);
            this.createTab.Controls.Add(this.map_create_map);
            this.createTab.Controls.Add(this.points_create_lst);
            this.createTab.Location = new System.Drawing.Point(4, 29);
            this.createTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.createTab.Name = "createTab";
            this.createTab.Size = new System.Drawing.Size(1567, 967);
            this.createTab.TabIndex = 1;
            this.createTab.Text = "Create";
            this.createTab.UseVisualStyleBackColor = true;
            // 
            // finish_create_btn
            // 
            this.finish_create_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finish_create_btn.Location = new System.Drawing.Point(910, 798);
            this.finish_create_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.finish_create_btn.Name = "finish_create_btn";
            this.finish_create_btn.Size = new System.Drawing.Size(250, 79);
            this.finish_create_btn.TabIndex = 3;
            this.finish_create_btn.Text = "Finish";
            this.finish_create_btn.UseVisualStyleBackColor = true;
            // 
            // parkName_create_txt
            // 
            this.parkName_create_txt.Location = new System.Drawing.Point(9, 65);
            this.parkName_create_txt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.parkName_create_txt.Name = "parkName_create_txt";
            this.parkName_create_txt.Size = new System.Drawing.Size(183, 26);
            this.parkName_create_txt.TabIndex = 2;
            this.parkName_create_txt.Text = "Parking name";
            // 
            // map_create_map
            // 
            this.map_create_map.BackColor = System.Drawing.Color.DarkRed;
            this.map_create_map.Location = new System.Drawing.Point(6, 138);
            this.map_create_map.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.map_create_map.Name = "map_create_map";
            this.map_create_map.Size = new System.Drawing.Size(1194, 632);
            this.map_create_map.TabIndex = 1;
            // 
            // points_create_lst
            // 
            this.points_create_lst.FormattingEnabled = true;
            this.points_create_lst.ItemHeight = 20;
            this.points_create_lst.Location = new System.Drawing.Point(1203, 8);
            this.points_create_lst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.points_create_lst.Name = "points_create_lst";
            this.points_create_lst.Size = new System.Drawing.Size(338, 884);
            this.points_create_lst.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.logger_mission_lst);
            this.tabPage1.Controls.Add(this.connected_mission_lbl);
            this.tabPage1.Controls.Add(this.abort_mission_btn);
            this.tabPage1.Controls.Add(this.stop_mission_btn);
            this.tabPage1.Controls.Add(this.end_mission_btn);
            this.tabPage1.Controls.Add(this.map_mission_map);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1567, 967);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Mission";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // logger_mission_lst
            // 
            this.logger_mission_lst.FormattingEnabled = true;
            this.logger_mission_lst.ItemHeight = 20;
            this.logger_mission_lst.Location = new System.Drawing.Point(9, 796);
            this.logger_mission_lst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logger_mission_lst.Name = "logger_mission_lst";
            this.logger_mission_lst.Size = new System.Drawing.Size(1536, 104);
            this.logger_mission_lst.TabIndex = 9;
            // 
            // connected_mission_lbl
            // 
            this.connected_mission_lbl.AutoSize = true;
            this.connected_mission_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connected_mission_lbl.ForeColor = System.Drawing.Color.LimeGreen;
            this.connected_mission_lbl.Location = new System.Drawing.Point(1297, 34);
            this.connected_mission_lbl.Name = "connected_mission_lbl";
            this.connected_mission_lbl.Size = new System.Drawing.Size(221, 48);
            this.connected_mission_lbl.TabIndex = 8;
            this.connected_mission_lbl.Text = "Connected";
            // 
            // abort_mission_btn
            // 
            this.abort_mission_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abort_mission_btn.Location = new System.Drawing.Point(348, 30);
            this.abort_mission_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.abort_mission_btn.Name = "abort_mission_btn";
            this.abort_mission_btn.Size = new System.Drawing.Size(122, 60);
            this.abort_mission_btn.TabIndex = 7;
            this.abort_mission_btn.Text = "Abort";
            this.abort_mission_btn.UseVisualStyleBackColor = true;
            // 
            // stop_mission_btn
            // 
            this.stop_mission_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop_mission_btn.Location = new System.Drawing.Point(226, 30);
            this.stop_mission_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stop_mission_btn.Name = "stop_mission_btn";
            this.stop_mission_btn.Size = new System.Drawing.Size(115, 60);
            this.stop_mission_btn.TabIndex = 6;
            this.stop_mission_btn.Text = "Stop";
            this.stop_mission_btn.UseVisualStyleBackColor = true;
            // 
            // end_mission_btn
            // 
            this.end_mission_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_mission_btn.Location = new System.Drawing.Point(12, 30);
            this.end_mission_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.end_mission_btn.Name = "end_mission_btn";
            this.end_mission_btn.Size = new System.Drawing.Size(207, 60);
            this.end_mission_btn.TabIndex = 5;
            this.end_mission_btn.Text = "End Mission";
            this.end_mission_btn.UseVisualStyleBackColor = true;
            // 
            // map_mission_map
            // 
            this.map_mission_map.BackColor = System.Drawing.Color.DarkRed;
            this.map_mission_map.Location = new System.Drawing.Point(9, 98);
            this.map_mission_map.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.map_mission_map.Name = "map_mission_map";
            this.map_mission_map.Size = new System.Drawing.Size(1537, 691);
            this.map_mission_map.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.MoveAmount);
            this.tabPage2.Controls.Add(this.moveDown_dummy_btn);
            this.tabPage2.Controls.Add(this.moveUp_dummy_btn);
            this.tabPage2.Controls.Add(this.moveRight_dummy_btn);
            this.tabPage2.Controls.Add(this.moveLeft_dummy_btn);
            this.tabPage2.Controls.Add(this.moveBackward_dummy_btn);
            this.tabPage2.Controls.Add(this.Landing_dummy_btn);
            this.tabPage2.Controls.Add(this.parking_mission_dummy_btn);
            this.tabPage2.Controls.Add(this.ConfirmLanding_dummy_btn);
            this.tabPage2.Controls.Add(this.moveGimbal_dummy_btn);
            this.tabPage2.Controls.Add(this.goToGPS_dummy_btn);
            this.tabPage2.Controls.Add(this.takePhoto_dummy_btn);
            this.tabPage2.Controls.Add(this.goHome_dummy_btn);
            this.tabPage2.Controls.Add(this.StartLanding_dummy_btn);
            this.tabPage2.Controls.Add(this.takeOff_dummy_btn);
            this.tabPage2.Controls.Add(this.moveForward_dummy_btn);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1567, 967);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Dummy";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MoveAmount
            // 
            this.MoveAmount.Location = new System.Drawing.Point(503, 179);
            this.MoveAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MoveAmount.Name = "MoveAmount";
            this.MoveAmount.Size = new System.Drawing.Size(82, 26);
            this.MoveAmount.TabIndex = 31;
            this.MoveAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // moveDown_dummy_btn
            // 
            this.moveDown_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveDown_dummy_btn.Location = new System.Drawing.Point(168, 260);
            this.moveDown_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveDown_dummy_btn.Name = "moveDown_dummy_btn";
            this.moveDown_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.moveDown_dummy_btn.TabIndex = 30;
            this.moveDown_dummy_btn.Text = "Move down";
            this.moveDown_dummy_btn.UseVisualStyleBackColor = true;
            this.moveDown_dummy_btn.Click += new System.EventHandler(this.moveDown_dummy_btn_Click);
            // 
            // moveUp_dummy_btn
            // 
            this.moveUp_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveUp_dummy_btn.Location = new System.Drawing.Point(1055, 260);
            this.moveUp_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveUp_dummy_btn.Name = "moveUp_dummy_btn";
            this.moveUp_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.moveUp_dummy_btn.TabIndex = 29;
            this.moveUp_dummy_btn.Text = "Move up";
            this.moveUp_dummy_btn.UseVisualStyleBackColor = true;
            this.moveUp_dummy_btn.Click += new System.EventHandler(this.moveUp_dummy_btn_Click);
            // 
            // moveRight_dummy_btn
            // 
            this.moveRight_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveRight_dummy_btn.Location = new System.Drawing.Point(1055, 348);
            this.moveRight_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveRight_dummy_btn.Name = "moveRight_dummy_btn";
            this.moveRight_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.moveRight_dummy_btn.TabIndex = 28;
            this.moveRight_dummy_btn.Text = "Move right";
            this.moveRight_dummy_btn.UseVisualStyleBackColor = true;
            this.moveRight_dummy_btn.Click += new System.EventHandler(this.moveRight_dummy_btn_Click);
            // 
            // moveLeft_dummy_btn
            // 
            this.moveLeft_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveLeft_dummy_btn.Location = new System.Drawing.Point(168, 348);
            this.moveLeft_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveLeft_dummy_btn.Name = "moveLeft_dummy_btn";
            this.moveLeft_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.moveLeft_dummy_btn.TabIndex = 27;
            this.moveLeft_dummy_btn.Text = "Move left";
            this.moveLeft_dummy_btn.UseVisualStyleBackColor = true;
            this.moveLeft_dummy_btn.Click += new System.EventHandler(this.moveLeft_dummy_btn_Click);
            // 
            // moveBackward_dummy_btn
            // 
            this.moveBackward_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveBackward_dummy_btn.Location = new System.Drawing.Point(614, 348);
            this.moveBackward_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveBackward_dummy_btn.Name = "moveBackward_dummy_btn";
            this.moveBackward_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.moveBackward_dummy_btn.TabIndex = 26;
            this.moveBackward_dummy_btn.Text = "Move backward";
            this.moveBackward_dummy_btn.UseVisualStyleBackColor = true;
            this.moveBackward_dummy_btn.Click += new System.EventHandler(this.moveBackward_dummy_btn_Click);
            // 
            // Landing_dummy_btn
            // 
            this.Landing_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Landing_dummy_btn.Location = new System.Drawing.Point(1055, 536);
            this.Landing_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Landing_dummy_btn.Name = "Landing_dummy_btn";
            this.Landing_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.Landing_dummy_btn.TabIndex = 25;
            this.Landing_dummy_btn.Text = "Landing";
            this.Landing_dummy_btn.UseVisualStyleBackColor = true;
            this.Landing_dummy_btn.Click += new System.EventHandler(this.Landing_dummy_btn_Click_1);
            // 
            // parking_mission_dummy_btn
            // 
            this.parking_mission_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parking_mission_dummy_btn.Location = new System.Drawing.Point(614, 21);
            this.parking_mission_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.parking_mission_dummy_btn.Name = "parking_mission_dummy_btn";
            this.parking_mission_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.parking_mission_dummy_btn.TabIndex = 24;
            this.parking_mission_dummy_btn.Text = "ParkingMission";
            this.parking_mission_dummy_btn.UseVisualStyleBackColor = true;
            this.parking_mission_dummy_btn.Click += new System.EventHandler(this.parking_mission_dummy_btn_Click);
            // 
            // ConfirmLanding_dummy_btn
            // 
            this.ConfirmLanding_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmLanding_dummy_btn.Location = new System.Drawing.Point(614, 536);
            this.ConfirmLanding_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfirmLanding_dummy_btn.Name = "ConfirmLanding_dummy_btn";
            this.ConfirmLanding_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.ConfirmLanding_dummy_btn.TabIndex = 23;
            this.ConfirmLanding_dummy_btn.Text = "Confirm Landing";
            this.ConfirmLanding_dummy_btn.UseVisualStyleBackColor = true;
            this.ConfirmLanding_dummy_btn.Click += new System.EventHandler(this.ConfirmLanding_dummy_btn_Click);
            // 
            // moveGimbal_dummy_btn
            // 
            this.moveGimbal_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveGimbal_dummy_btn.Location = new System.Drawing.Point(1055, 734);
            this.moveGimbal_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveGimbal_dummy_btn.Name = "moveGimbal_dummy_btn";
            this.moveGimbal_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.moveGimbal_dummy_btn.TabIndex = 22;
            this.moveGimbal_dummy_btn.Text = "Move Gimbal";
            this.moveGimbal_dummy_btn.UseVisualStyleBackColor = true;
            this.moveGimbal_dummy_btn.Click += new System.EventHandler(this.moveGimbal_dummy_btn_Click);
            // 
            // goToGPS_dummy_btn
            // 
            this.goToGPS_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goToGPS_dummy_btn.Location = new System.Drawing.Point(614, 725);
            this.goToGPS_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.goToGPS_dummy_btn.Name = "goToGPS_dummy_btn";
            this.goToGPS_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.goToGPS_dummy_btn.TabIndex = 21;
            this.goToGPS_dummy_btn.Text = "Go To GPS";
            this.goToGPS_dummy_btn.UseVisualStyleBackColor = true;
            this.goToGPS_dummy_btn.Click += new System.EventHandler(this.goToGPS_dummy_btn_Click);
            // 
            // takePhoto_dummy_btn
            // 
            this.takePhoto_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takePhoto_dummy_btn.Location = new System.Drawing.Point(168, 725);
            this.takePhoto_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.takePhoto_dummy_btn.Name = "takePhoto_dummy_btn";
            this.takePhoto_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.takePhoto_dummy_btn.TabIndex = 20;
            this.takePhoto_dummy_btn.Text = "Take Photo";
            this.takePhoto_dummy_btn.UseVisualStyleBackColor = true;
            this.takePhoto_dummy_btn.Click += new System.EventHandler(this.takePhoto_dummy_btn_Click);
            // 
            // goHome_dummy_btn
            // 
            this.goHome_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goHome_dummy_btn.Location = new System.Drawing.Point(614, 623);
            this.goHome_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.goHome_dummy_btn.Name = "goHome_dummy_btn";
            this.goHome_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.goHome_dummy_btn.TabIndex = 18;
            this.goHome_dummy_btn.Text = "Go Home";
            this.goHome_dummy_btn.UseVisualStyleBackColor = true;
            this.goHome_dummy_btn.Click += new System.EventHandler(this.goHome_dummy_btn_Click);
            // 
            // StartLanding_dummy_btn
            // 
            this.StartLanding_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartLanding_dummy_btn.Location = new System.Drawing.Point(168, 536);
            this.StartLanding_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StartLanding_dummy_btn.Name = "StartLanding_dummy_btn";
            this.StartLanding_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.StartLanding_dummy_btn.TabIndex = 16;
            this.StartLanding_dummy_btn.Text = "Start Landing ";
            this.StartLanding_dummy_btn.UseVisualStyleBackColor = true;
            this.StartLanding_dummy_btn.Click += new System.EventHandler(this.Landing_dummy_btn_Click);
            // 
            // takeOff_dummy_btn
            // 
            this.takeOff_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeOff_dummy_btn.Location = new System.Drawing.Point(614, 453);
            this.takeOff_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.takeOff_dummy_btn.Name = "takeOff_dummy_btn";
            this.takeOff_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.takeOff_dummy_btn.TabIndex = 15;
            this.takeOff_dummy_btn.Text = "Take Off ";
            this.takeOff_dummy_btn.UseVisualStyleBackColor = true;
            this.takeOff_dummy_btn.Click += new System.EventHandler(this.takeOff_dummy_btn_Click);
            // 
            // moveForward_dummy_btn
            // 
            this.moveForward_dummy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveForward_dummy_btn.Location = new System.Drawing.Point(614, 260);
            this.moveForward_dummy_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveForward_dummy_btn.Name = "moveForward_dummy_btn";
            this.moveForward_dummy_btn.Size = new System.Drawing.Size(417, 60);
            this.moveForward_dummy_btn.TabIndex = 14;
            this.moveForward_dummy_btn.Text = "Move forward";
            this.moveForward_dummy_btn.UseVisualStyleBackColor = true;
            this.moveForward_dummy_btn.Click += new System.EventHandler(this.move_dummy_btn_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1550, 930);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1572, 986);
            this.MinimumSize = new System.Drawing.Size(1572, 986);
            this.Name = "GUI";
            this.Text = "Drone Server";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.tabControl.ResumeLayout(false);
            this.homeTab.ResumeLayout(false);
            this.createTab.ResumeLayout(false);
            this.createTab.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MoveAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage homeTab;
        private System.Windows.Forms.ListBox parkings_home_btn;
        private System.Windows.Forms.TabPage createTab;
        private System.Windows.Forms.Button start_home_btn;
        private System.Windows.Forms.ListBox logger_home_lst;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox parkName_create_txt;
        private System.Windows.Forms.Panel map_create_map;
        private System.Windows.Forms.ListBox points_create_lst;
        private System.Windows.Forms.Button finish_create_btn;
        private System.Windows.Forms.ListBox logger_mission_lst;
        private System.Windows.Forms.Label connected_mission_lbl;
        private System.Windows.Forms.Button abort_mission_btn;
        private System.Windows.Forms.Button stop_mission_btn;
        private System.Windows.Forms.Button end_mission_btn;
        private System.Windows.Forms.Panel map_mission_map;
        private System.Windows.Forms.Button moveGimbal_dummy_btn;
        private System.Windows.Forms.Button goToGPS_dummy_btn;
        private System.Windows.Forms.Button takePhoto_dummy_btn;
        private System.Windows.Forms.Button goHome_dummy_btn;
        private System.Windows.Forms.Button StartLanding_dummy_btn;
        private System.Windows.Forms.Button takeOff_dummy_btn;
        private System.Windows.Forms.Button moveForward_dummy_btn;
        private System.Windows.Forms.Button ConfirmLanding_dummy_btn;
        private System.Windows.Forms.Button parking_mission_dummy_btn;
        private System.Windows.Forms.Button Landing_dummy_btn;
        private System.Windows.Forms.Button moveBackward_dummy_btn;
        private System.Windows.Forms.Button moveDown_dummy_btn;
        private System.Windows.Forms.Button moveUp_dummy_btn;
        private System.Windows.Forms.Button moveRight_dummy_btn;
        private System.Windows.Forms.Button moveLeft_dummy_btn;
        private System.Windows.Forms.NumericUpDown MoveAmount;
    }
}

