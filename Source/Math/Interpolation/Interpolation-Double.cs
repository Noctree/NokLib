using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math = System.Math;

namespace NokLib
{
    /// <summary>
    /// Methods for interpolating double values
    /// </summary>
    public static class InterpolationD
    {
        public static double Linear(double a, double b, double time)
        {
            return a * (1 - time) + time * b;
        }

        public static double LinearClamped(double a, double b, double time)
        {
            return Linear(a, b, MathN.Clamp01(time));
        }

        /// <summary>
        /// Linear interpolation with time clamped between -1 and 1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double LinearSignedClamped(double a, double b, double time)
        {
            return Linear(a, b, MathN.Clamp(-1, 1, time));
        }

        public static double QuadEaseIn(double a, double b, double time)
        {
            return b * time * time + a;
        }

        public static double QuadEaseOut(double a, double b, double time)
        {
            return -b * time * (time - 2) + a;
        }

        public static double QuadEaseInOut(double a, double b, double time)
        {
            time /= 0.5f;
            if (time < 1)
                return b / 2 * (time * time) + a;

            time--;
            return -b / 2 * (time * (time - 2) - 1) + a;
        }

        public static double CubeEaseIn(double a, double b, double time)
        {
            return b * (time * time * time) + a;
        }
    }
}
