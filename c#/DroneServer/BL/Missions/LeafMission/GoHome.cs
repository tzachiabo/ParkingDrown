﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServer.BL.Missions
{
    class GoHome : LeafMission
    {

        public GoHome() : base()
        {

        }

        public override string encode()
        {
            return "goHome " + m_index;
        }

        public override void stop()
        {
           
        }
    }
}
