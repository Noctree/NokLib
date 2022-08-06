using System;
using System.Collections.Generic;

namespace NokLib;

/// <summary>
/// Class for converting enums to strings, works by caching all enum string values in a dictionary. Thanks to caching its a lot faster and allocation free
/// </summary>
public static class EnumStringifier
{
    /// <summary>
    /// Converts the enum to string, creates a conversion table if the enum is being converted for the first time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToString<T>(T value) where T : unmanaged, Enum => EnumValueCache<T>.ConvertToString(value);

    /// <summary>
    /// Returns names of each enum value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static IReadOnlyList<string> GetNames<T>() where T : unmanaged, Enum => EnumValueCache<T>.Names;
    public static IReadOnlyList<T> GetValues<T>() where T : unmanaged, Enum => EnumValueCache<T>.Values;
}
