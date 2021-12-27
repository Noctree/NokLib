﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NokLib
{
    public static class CastingExtensions
    {
        /// <summary>
        /// If true, returns 1, else returns 0
        /// </summary>
        /// <param name="boolean"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this bool boolean)
        {
            if (boolean)
                return 1;
            return 0;
        }

        /// <summary>
        /// If 0, returns false, else returns true
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this int val)
        {
            return val != 0;
        }

        /// <summary>
        ///  Returns an array of all enum values of the calling enum
        /// </summary>
        /// <typeparam name="T">enum which values should be converted</typeparam>
        /// <param name="_enum"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] ToArray<T>(this T _enum) where T : Enum
        {
            return Enum.GetValues(_enum.GetType()).Cast<T>().ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] ToStringArray<T>(this T _enum) where T : Enum
        {
            return Enum.GetNames(_enum.GetType());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt<T>(this T value) where T : Enum
        {
            return (int)(object)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ToEnum<T>(this int value) where T : Enum
        {
            return (T)(object)value;
        }

        /// <summary>
        /// Shorthand for writing (float)value
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this double d) => (float)d;
    }
}
