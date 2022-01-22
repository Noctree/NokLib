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
        private static Dictionary<Type, IEnumConverter> stringifiedEnums;

        static EnumStringifier()
        {
            stringifiedEnums = new Dictionary<Type, IEnumConverter>();
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
            return stringifiedEnums[typeof(T)].Convert(value);
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
            var enumType = typeof(T);
            var baseType = Enum.GetUnderlyingType(enumType);

            if (baseType == typeof(long))
                stringifiedEnums.Add(enumType, new LongEnumConverter(enumType));
            else if (baseType == typeof(int))
                stringifiedEnums.Add(enumType, new IntEnumConverter(enumType));
            else if (baseType == typeof(short))
                stringifiedEnums.Add(enumType, new ShortEnumConverter(enumType));
            else if (baseType == typeof(byte))
                stringifiedEnums.Add(enumType, new ByteEnumConverter(enumType));
            else
                throw new UnsupportedOperationException("Enum underlying type " + enumType + " is not supported");
        }
    }

    internal interface IEnumConverter
    {
        public string Convert<T>(T value) where T : Enum;
        public string[] GetNames();
    }

    internal abstract class EnumConverterBase<T> : IEnumConverter where T : struct, IConvertible
    {
        protected readonly Dictionary<T, string> strings;
        public EnumConverterBase(Type enumType)
        {
            var values = Enum.GetValues(enumType).Cast<T>().ToArray();
            string[] names = Enum.GetNames(enumType);

            if (values.Length != names.Length)
                throw new SizeMismatchException("Enum.GetValues returned an array of different length than Enum.GetNames");
            strings = new Dictionary<T, string>(values.Length);
            for (int i = 0; i < values.Length; i++) {
                strings.Add(values[i], names[i]);
            }
        }

        public string[] GetNames() => strings.Values.ToArray();

        public abstract string Convert<T>(T index) where T : Enum;
    }

    internal class LongEnumConverter : EnumConverterBase<long>
    {
        private static readonly Type Long = typeof(long);
        public LongEnumConverter(Type enumType) : base(enumType) { }

        public override string Convert<T>(T index) => strings[(long)System.Convert.ChangeType(index, Long)];
    }

    internal class IntEnumConverter : EnumConverterBase<int>
    {
        private static readonly Type Int = typeof(int);
        public IntEnumConverter(Type enumType) : base(enumType) { }

        public override string Convert<T>(T index) => strings[(int)System.Convert.ChangeType(index, Int)];
    }

    internal class ShortEnumConverter : EnumConverterBase<short>
    {
        private static readonly Type Short = typeof(short);
        public ShortEnumConverter(Type enumType) : base(enumType) { }

        public override string Convert<T>(T index) => strings[(short)System.Convert.ChangeType(index, Short)];
    }

    internal class ByteEnumConverter : EnumConverterBase<byte>
    {
        private static readonly Type Byte = typeof(byte);
        public ByteEnumConverter(Type enumType) : base(enumType) { }

        public override string Convert<T>(T index) => strings[(byte)System.Convert.ChangeType(index, Byte)];
    }
}
