<<<<<<< HEAD
﻿using DroneServer.SharedClasses;
using System;
=======
﻿using System;
>>>>>>> 1bdffa1... add map to gui
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServer.BL.Missions
{
    class MoveGimbal : LeafMission
    {
<<<<<<< HEAD
        private Gimbal m_gimbal;
        private double m_roll;
        private double m_pitch;
        private double m_yaw;

        public MoveGimbal(Gimbal gimbal, double roll, double pitch, double yaw) : base()
        {
            m_gimbal = gimbal;
            m_roll = roll;
            m_pitch = pitch;
            m_yaw = yaw;
        }


        public override string encode()
        {
            return "moveGimbal " + m_index + " " + m_gimbal + " " + m_roll + " " + m_pitch + " " + m_yaw;
        }

        public override void stop()
        {
            throw new NotImplementedException();
=======
        private double horizontal;
        private double vertical;

        public MoveGimbal(double horizontal, double vertical):base()
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
        }

        public override void stop()
        {

        }

        public override string encode()
        {
            return "moveGimbal " + m_index + " " + horizontal + " " + vertical;
>>>>>>> 1bdffa1... add map to gui
        }
    }
}
