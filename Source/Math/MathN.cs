namespace NokLib
{
    /// <summary>
    /// Basic math library
    /// </summary>
    public static class MathN
    {
        public static double Clamp01(double value) {
            return Clamp(0, 1, value);
        }

        public static double Clamp(double min, double max, double value) {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
    }
}
