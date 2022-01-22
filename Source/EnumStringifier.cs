using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NokLib
{
    /// <summary>
    /// Class for converting enums to strings, works by caching all enum string values in a dictionary. While slightly slower than regular ToString method (~+7 ns/op), this class does not generate any garbage during conversion
    /// </summary>
    public static class EnumStringifier
    {
        private static Dictionary<Type, EnumConverter> stringifiedEnums;

        static EnumStringifier()
        {
            stringifiedEnums = new Dictionary<Type, EnumConverter>();
        }

        /// <summary>
        /// Converts the enum to string, creates a conversion table if the enum is being converted for the first time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString<T>(T value) where T : Enum
        {
            if (!stringifiedEnums.ContainsKey(typeof(T)))
                CreateEnumConversionTable<T>();
            return (stringifiedEnums[typeof(T)] as EnumConverter<T>).Convert(value);
        }

        /// <summary>
        /// Returns names of each enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string[] GetNames<T>() where T : Enum
        {
            if (!stringifiedEnums.ContainsKey(typeof(T)))
                CreateEnumConversionTable<T>();
            return stringifiedEnums[typeof(T)].GetNames();
        }

        /// <summary>
        /// Release resources occupied by a conversion table for enum of type T. Useful for usage with large enums
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Release<T>()
        {
            if (stringifiedEnums.ContainsKey(typeof(T)))
                stringifiedEnums.Remove(typeof(T));
        }

        private static void CreateEnumConversionTable<T>() where T : Enum
        {
            stringifiedEnums.Add(typeof(T), new EnumConverter<T>());
        }
    }

    internal abstract class EnumConverter
    {
        public abstract string[] GetNames();
    }

    internal class EnumConverter<T> : EnumConverter where T : Enum
    {
        protected readonly Dictionary<T, string> strings;
        public EnumConverter()
        {
            var enumType = typeof(T);
            var values = Enum.GetValues(enumType).Cast<T>().ToArray();
            string[] names = Enum.GetNames(enumType);

            if (values.Length != names.Length)
                throw new SizeMismatchException("Enum.GetValues returned an array of different length than Enum.GetNames");
            strings = new Dictionary<T, string>(values.Length);
            for (int i = 0; i < values.Length; i++) {
                strings.Add(values[i], names[i]);
            }
        }

        public override string[] GetNames()
        {
            string[] names = new string[strings.Count];
            strings.Values.CopyTo(names, 0);
            return names;
        }

        public string Convert(T index) => strings[index];
    }
}
