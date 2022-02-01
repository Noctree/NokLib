using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math = System.Math;

namespace NokLib
{
    /// <summary>
    /// Methods for interpolating float values
    /// </summary>
    public static class InterpolationF
    {
        public static float Linear(float a, float b, float time)
        {
            return a * (1 - time) + time * b;
        }

        public static float LinearClamped(float a, float b, float time)
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
        public static float LinearSignedClamped(float a, float b, float time)
        {
            return Linear(a, b, MathN.Clamp(-1, 1, time));
        }

        public static float QuadEaseIn(float a, float b, float time)
        {
            return b * time * time + a;
        }

        public static float QuadEaseOut(float a, float b, float time)
        {
            return -b * time * (time - 2) + a;
        }

        public static float QuadEaseInOut(float a, float b, float time)
        {
            time /= 0.5f;
            if (time < 1)
                return b / 2 * (time * time) + a;

            time--;
            return -b / 2 * (time * (time - 2) - 1) + a;
        }

        public static float CubeEaseIn(float a, float b, float time)
        {
            return b * (time * time * time) + a;
        }
    }
}
