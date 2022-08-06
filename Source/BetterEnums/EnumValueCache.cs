using System;
using System.Collections.Generic;


namespace NokLib;
public static class EnumValueCache<T> where T : unmanaged, Enum
{
    private static readonly string[] names;
    private static readonly T[] values;
    private static readonly Dictionary<long, string> nameDict;
    public static IReadOnlyList<string> Names => names.AsReadOnly();
    public static IReadOnlyList<T> Values => values.AsReadOnly();
    static EnumValueCache() {
        values = Enum.GetValues<T>();
        names = Enum.GetNames<T>();

        if (names.Length != values.Length)
            throw new SizeMismatchException(values.Length, names.Length, "Enum.GetValues and Enum.GetNames have returned arrays of different lengths for type " + typeof(T));

        nameDict = new();
        for (int i = 0; i < names.Length; ++i)
            nameDict.Add(values[i].ToLongFast(), names[i]);
    }

    public static string ConvertToString(T value) => nameDict[value.ToLongFast()];
    public static bool IsDefined(long value) => nameDict.ContainsKey(value);
    public static bool TryParse(string input, out T value) {
        value = default;
        for (int i = 0; i < values.Length; ++i)
            if (string.Equals(input, names[i])) {
                value = values[i];
                return true;
            }
        return false;
    }

    public static bool TryParse(string input, StringComparer comparer, out T value) {
        value = default;
        for (int i = 0; i < values.Length; ++i) {
            if (comparer.Compare(names[i], input) == 0) {
                value = values[i];
                return true;
            }
        }
        return false;
    }
}
