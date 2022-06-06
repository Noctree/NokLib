using System;
using System.Collections.Generic;
using System.Linq;

namespace NokLib
{
    /// <summary>
    /// Class for converting enums to strings, works by caching all enum string values in a dictionary. Thanks to caching its a lot faster and allocation free
    /// </summary>
    public static class EnumStringifier
    {
        static class EnumCache<T> where T : unmanaged, Enum {
            static EnumCache() {
                names = Enum.GetNames<T>().ToList();
                nameDict = Enum.GetValues<T>().ToDictionary(val => val.ToLongFast(), val => val.ToString());
            }

            private static List<string> names;
            private static Dictionary<long, string> nameDict;
            public static IReadOnlyList<string> Names => names.AsReadOnly();
            public static string Convert(T value) => nameDict[value.ToLongFast()];
        }
        /// <summary>
        /// Converts the enum to string, creates a conversion table if the enum is being converted for the first time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString<T>(T value) where T : unmanaged, Enum => EnumCache<T>.Convert(value);

        /// <summary>
        /// Returns names of each enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static IReadOnlyList<string> GetNames<T>() where T : unmanaged, Enum => EnumCache<T>.Names;
    }
}
