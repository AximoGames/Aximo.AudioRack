﻿// This file is part of Aximo, a Game Engine written in C#. Web: https://github.com/AximoGames
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Aximo.Engine;
using OpenToolkit.Mathematics;
using OpenToolkit.Windowing.Common;

namespace Aximo.Audio.Rack.Gui
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var config = new ApplicationConfig
            {
                WindowTitle = "Aximo Audio Rack",
                WindowSize = new Vector2i(800, 600),
                WindowBorder = WindowBorder.Resizable,
                IsMultiThreaded = true,
                RenderFrequency = 0,
                UpdateFrequency = 0,
                IdleRenderFrequency = 0,
                IdleUpdateFrequency = 0,
                VSync = VSyncMode.Off,
                // UseGtkUI = true,
                UseConsole = true,
            };
            new RackApplication().Start(config);
        }
    }
}
