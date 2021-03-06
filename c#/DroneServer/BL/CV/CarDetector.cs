﻿using DroneServer.SharedClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServer.BL
{
    public class CarDetector
    {
        public static List<Car> getCarsFromBasePhoto(String base_photo_path, double base_photo_height)
        {
            Logger.getInstance().info("start carDetector with YOLOV3");

            System.Threading.Thread.Sleep(2000);

            String[] module_result = run_car_detector_module(base_photo_path);

            List<Car> cars = generate_cars_objects(module_result, base_photo_height);

            Logger.getInstance().info("finish carDetector with YOLOV3 detect " + cars.Count + " cars");

            return cars;
        }

        private static String[] run_car_detector_module(String base_photo_path)
        {

            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("python");

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.CreateNoWindow = true;

            String myPythonApp = "car_detector.py "+ base_photo_path;
            Logger.getInstance().info("CV CarDetector params: " + myPythonApp);
            myProcessStartInfo.Arguments = myPythonApp;

            Process myProcess = new Process();
            myProcess.StartInfo = myProcessStartInfo;

            // start the process 
            myProcess.Start();
            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadToEnd();
            myProcess.WaitForExit();
            Logger.getInstance().info("CV CarDetector result: " + myString);

            return myString.Split('\n');
        }


        private static List<Car> generate_cars_objects(String[] module_result, double base_photo_height)
        {
            List<Car> res = new List<Car>();

            foreach (String line in module_result)
            {
                
                String[] colums = line.Split('\t');
                if (colums.Length == 6)
                {
                    String type = colums[0];
                    int precent = Int32.Parse(colums[1].Substring(0, colums[1].Length - 1));
                    int margin_left = Int32.Parse(colums[2]);
                    int margin_top = Int32.Parse(colums[3]);
                    int width = Int32.Parse(colums[4]);
                    int height = Int32.Parse(colums[5]);
                    if(is_valid_car(margin_left, margin_top, width, height))
                    {
                        Car car = new Car(type, precent, margin_left, margin_top, width, height, base_photo_height);
                        res.Add(car);

                    }

                }
            }

            return res;
        }

        private static bool is_valid_car(int margin_left, int margin_top, int width, int height)
        {
            int car_min_margin_left = Int32.Parse(Configuration.getInstance().get("car_min_margin_left"));
            int car_min_margin_top = Int32.Parse(Configuration.getInstance().get("car_min_margin_top"));
            int car_min_height = Int32.Parse(Configuration.getInstance().get("car_min_height"));
            int car_min_width = Int32.Parse(Configuration.getInstance().get("car_min_width"));

            return margin_left > car_min_margin_left && margin_top > car_min_margin_top &&
                   width > car_min_width && height > car_min_height;
        }

    }

}
