using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NokLib;

public static class EnumExtensions
{
    /// <summary>
    /// Converts the value to string using EnumStringifier
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="val"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToStringNonAlloc<T>(this T val) where T : unmanaged, Enum => EnumValueCache<T>.ConvertToString(val);

    /// <summary>
    ///  Returns an array of all enum values of the calling enum
    /// </summary>
    /// <typeparam name="T">enum which values should be converted</typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<T> GetValues<T>(this T _) where T : unmanaged, Enum => EnumValueCache<T>.Values;

    /// <summary>
    /// Returns an array of all enum value names
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_enum"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<string> GetNames<T>(this T _) where T : unmanaged, Enum => EnumValueCache<T>.Names;
}
