﻿// This file is part of Aximo, a Game Engine written in C#. Web: https://github.com/AximoGames
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;

namespace Aximo.Engine.Audio.Modules
{
    public class AudioDebugLogValuesModule : AudioModule
    {
        private Stream Stream;
        private StreamWriter StreamWriter;

        public void SetOutputStream(Stream stream)
        {
            Stream = stream;
            StreamWriter = new StreamWriter(stream);
        }

        public void SetOutputFile(string file)
        {
            if (File.Exists(file))
                File.Delete(file);

            SetOutputStream(File.OpenWrite(file));
        }

        public AudioDebugLogValuesModule()
        {
            Name = "Debug Values";
            ConfigureInput(0, "Probe");
            InputChannels = new Port[] { Inputs[0] };
        }

        private Port[] InputChannels;

        private short Value;
        public override void Process(AudioProcessArgs e)
        {
            if (Stream != null)
                for (var i = 0; i < InputChannels.Length; i++)
                {
                    //var v = 4.8822002f;
                    var voltage = InputChannels[i].GetVoltage();
                    var value = PCMConversion.FloatToShort(voltage);
                    if (value == -3 && value == Value)
                    {
                        var s = "";
                    }
                    Value = value;
                    StreamWriter.WriteLine(e.Tick + ": " + value);
                    //if (AxMath.Approximately(voltage, v))
                    //{
                    //    var s = "";
                    //}
                }
        }
    }
}
