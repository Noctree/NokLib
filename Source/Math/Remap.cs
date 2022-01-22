using System;
using System.Collections.Generic;
using System.Text;

namespace NokLib
{
    /// <summary>
    /// Methods for remapping values from old range to new
    /// </summary>
    public static partial class Remap
    {
        public static int Number(int fromMin, int fromMax, int toMin, int toMax, int value)
        {
            return toMin + (value - fromMin) * (toMax - fromMax) / (fromMax - fromMin);
        }

        public static long Number(long fromMin, long fromMax, long toMin, long toMax, long value)
        {
            return toMin + (value - fromMin) * (toMax - fromMax) / (fromMax - fromMin);
        }

        public static double Number(float fromMin, float fromMax, float toMin, float toMax, float value)
        {
            return toMin + (value - fromMin) * (toMax - fromMax) / (fromMax - fromMin);
        }

        public static double Number(double fromMin, double fromMax, double toMin, double toMax, double value)
        {
            return toMin + (value - fromMin) * (toMax - fromMax) / (fromMax - fromMin);
        }
    }
}
