﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServer.BL.Missions
{
    class TakeOff:LeafMission
    {
<<<<<<< HEAD
        public TakeOff() { }

        public TakeOff(ComplexMission mission) { m_ParentMission = mission; }
=======
        public TakeOff() : base()
        {

        }
>>>>>>> 1bdffa1... add map to gui

        public override void stop()
        {

        }

        public override string encode()
        {
            return "takeOff " + m_index;
        }

    }
}
