using System;
using System.Runtime.CompilerServices;

namespace NokLib
{
    public static class NumericExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDigitAtIndex(this int number, int index) {
            return (int)((number / Math.Pow(10, number.GetDigitCount() - index - 1)) % 10);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDigitAtIndex(this float number, int index) {
            return (int)((number / Math.Pow(10, number.GetDigitCount() - index - 1)) % 10);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDigitAtIndex(this double number, int index) {
            return (int)((number / Math.Pow(10, number.GetDigitCount() - index - 1)) % 10);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDigitCount(this int number) {
            return (int)Math.Log10(number) + 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDigitCount(this float number) {
            return (int)Math.Log10(number) + 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDigitCount(this double number) {
            return (int)Math.Log10(number) + 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPow2(this int number) {
            return number % 2 == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPow2(this float number) {
            return number % 2 == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPow2(this double number) {
            return number % 2 == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AlmostEquals(this float a, float b) {
            return a - b <= float.Epsilon;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AlmostEquals(this float a, float b, float precision) {
            return a - b <= precision;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AlmostEquals(this double a, double b) {
            return a - b <= double.Epsilon;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AlmostEquals(this double a, double b, double precision) {
            return a - b <= precision;
        }
    }
}
