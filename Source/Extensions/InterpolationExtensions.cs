namespace NokLib;
public static class InterpolationExtensions
{
    public static float Map(this float value, float inputFrom, float inputTo, float outputFrom, float outputTo) {
        return (value - inputFrom) / (inputTo - inputFrom) * (outputTo - outputFrom) + outputFrom;
    }

    public static int Map(this int value, int inputFrom, int inputTo, int outputFrom, int outputTo) {
        return (value - inputFrom) / (inputTo - inputFrom) * (outputTo - outputFrom) + outputFrom;
    }
}
