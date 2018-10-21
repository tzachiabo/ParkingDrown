﻿using DroneServer.BL.Missions;
using DroneServer.SharedClasses;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DroneServer.BL.Comm
{
    class ResponseConsumer
    {
        private ConcurrentDictionary<int, Mission> m_missions;
        private ConcurrentQueue<Response> m_responses;
        private Thread thread;

        public ResponseConsumer(ConcurrentDictionary<int, Mission> missions, 
                                ConcurrentQueue<Response> responses)
        {
            m_missions = missions;
            m_responses = responses;

            thread = new Thread(() =>
            {
                while (true)
                {
                    Response current_response;
                    if (m_responses.TryDequeue(out current_response))
                    {
                        Mission mission;

                        bool res = m_missions.TryRemove(current_response.Key, out mission);
                        Assertions.verify(res, "main mission thread tried faild to remove a response from queue");

                        mission.done(); //TODO may do done on ack message
                    }
                }
            });

            thread.Start();
        }
    }
}