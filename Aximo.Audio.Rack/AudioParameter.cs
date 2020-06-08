﻿// This file is part of Aximo, a Game Engine written in C#. Web: https://github.com/AximoGames
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;

namespace Aximo.Engine.Audio
{

    public class AudioParameter
    {
        public AudioModule Module;
        public string Name;
        public float Min;
        public float Max;
        public float Value;

        public AudioParameter(AudioModule module, string name, float min, float max)
        {
            Module = module;
            Name = name;
            Min = min;
            Max = max;
            Value = min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void SetValue(float value)
        {
            Value = MathF.Max(MathF.Min(value, Max), Min);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public float GetValue() => Value;

    }
}