using System;
using System.Runtime.CompilerServices;

namespace NokLib
{
    public static class CastingExtensions
    {
        /// <summary>
        /// If true, returns 1, else returns 0
        /// </summary>
        /// <param name="boolean"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this bool boolean) {
            if (boolean)
                return 1;
            return 0;
        }

        /// <summary>
        /// If 0, returns false, else returns true
        /// </summary>
        /// <param name="val"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this int val) {
            return val != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte<T>(this T value) where T : Enum {
            return (byte)(object)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToShort<T>(this T value) where T : Enum {
            return (short)(object)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt<T>(this T value) where T : Enum {
            return (int)(object)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToLong<T>(this T value) where T : Enum {
            return (long)(object)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ToEnum<T>(this int value) where T : Enum {
            return (T)(object)value;
        }

        /// <summary>
        /// Shorthand for writing (float)value
        /// </summary>
        /// <param name="d"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this double d) => (float)d;
    }
}
