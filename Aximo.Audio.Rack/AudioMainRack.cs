﻿// This file is part of Aximo, a Game Engine written in C#. Web: https://github.com/AximoGames
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Aximo.Audio.Rack.JsonModel;
//using System.Media;

namespace Aximo.Engine.Audio
{
    public class AudioMainRack : AudioRack
    {

        public override void Process(AudioProcessArgs e)
        {
            var tasks = Tasks;
            lock (tasks)
            {
                while (tasks.Count > 0)
                {
                    var task = tasks.Dequeue();
                    task();
                }
            }

            base.Process(e);

            Tick++;
        }

        public long Tick;

        private bool Running;
        public void MainLoop()
        {
            Running = true;
            var e = new AudioProcessArgs();
            e.SampleRate = 44100;
            while (Running)
            {
                e.SampleTime = 1f / e.SampleRate;
                e.Tick = Tick;
                Process(e);
            }
        }

        private Thread Thread;
        public void StartThread()
        {
            Thread = new Thread(MainLoop);
            Thread.Priority = ThreadPriority.Highest;
            Thread.IsBackground = false;
            Thread.Start();
            Thread.Sleep(1000); // TODO: use waiter!
        }

        private Queue<Action> Tasks = new Queue<Action>();
        public void Dispatch(Action task)
        {
            lock (Tasks)
                Tasks.Enqueue(task);
        }

        public void Stop()
        {
            Running = false;
        }

    }
}
