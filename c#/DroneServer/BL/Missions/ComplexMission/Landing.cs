﻿using DroneServer.SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServer.BL.Missions
{
    public class Landing : ComplexMission
    {
        public Landing(ComplexMission ParentMission = null) : base(ParentMission)
        {
            m_ParentMission = ParentMission;
            m_SubMission.Enqueue(new StartLanding(this));
            //em_SubMission.Enqueue(new ConfirmLanding(this));
        }

        public override void stop()
        {
        }

    }
}
