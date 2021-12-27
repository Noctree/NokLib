using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class MathN
    {
        public static double Clamp01(double value)
        {
            return Clamp(0, 1, value);
        }

        public static double Clamp(double min, double max, double value)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
    }
}
