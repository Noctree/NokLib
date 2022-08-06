using System;
using System.Runtime.CompilerServices;

namespace NokLib;

public static class CastingExtensions
{
    /// <summary>
    /// If true, returns 1, else returns 0
    /// </summary>
    /// <param name="boolean"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ToInt(this bool boolean) => boolean ? 1 : 0;

    /// <summary>
    /// If 0, returns false, else returns true
    /// </summary>
    /// <param name="val"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ToBool(this int val) => val != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToByte<T>(this T value) where T : Enum => (byte)(object)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short ToShort<T>(this T value) where T : Enum => (short)(object)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ToInt<T>(this T value) where T : Enum => (int)(object)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long ToLong<T>(this T value) where T : Enum => (long)(object)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ToEnum<T>(this byte value) where T : Enum => (T)(object)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ToEnum<T>(this short value) where T : Enum => (T)(object)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ToEnum<T>(this int value) where T : Enum => (T)(object)value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ToEnum<T>(this long value) where T : Enum => (T)(object)value;

    /// <summary>
    /// Shorthand for writing (float)value
    /// </summary>
    /// <param name="d"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ToFloat(this double d) => (float)d;
}
