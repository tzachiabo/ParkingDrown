﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServer.SharedClasses
{
    class Assertions
    {
        public static void verify(bool predicat, string message)
        {
            if (!predicat)
            {
                //TODO add message to logs
                System.Windows.Forms.Application.Exit();
            }

        }
    }
}
