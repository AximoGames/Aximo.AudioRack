﻿// This file is part of Aximo, a Game Engine written in C#. Web: https://github.com/AximoGames
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;

namespace Aximo.Engine.Audio.Modules
{

    public class AudioPCMFileSinkModule : AudioModule
    {
        public AudioSinkStream OutputStream;

        public void SetOutputStream(AudioSinkStream stream)
        {
            OutputStream = stream;
        }

        public AudioPCMFileSinkModule()
        {
            Name = "PCM Sink";
            ConfigureInput(0, "Left");
            ConfigureInput(1, "Right");
            ConfigureInput(2, "Gate");
            InputChannels = new Port[] { Inputs[0], Inputs[1] };
        }

        private Port[] InputChannels;

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Process(AudioProcessArgs e)
        {
            if (Inputs[2].GetVoltage() >= 0.9f)
                for (var i = 0; i < InputChannels.Length; i++)
                    OutputStream.Write(PCMConversion.FloatToShort(InputChannels[i].GetVoltage() / 5f));
        }
    }
}
