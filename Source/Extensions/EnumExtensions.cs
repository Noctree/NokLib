using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace NokLib
{
    public static class EnumExtensions
    {

        /// <summary>
        /// Converts the value to string using EnumStringifier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToStringNonAlloc<T>(this T val) where T : Enum
        {
            return EnumStringifier.ToString(val);
        }


        /// <summary>
        ///  Returns an array of all enum values of the calling enum
        /// </summary>
        /// <typeparam name="T">enum which values should be converted</typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] GetValues<T>(this T _) where T : Enum
        {
            return Enum.GetValues(typeof(T)) as T[];
        }

        /// <summary>
        /// Returns an array of all enum value names
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_enum"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] GetNames<T>(this T _enum) where T : Enum
        {
            return Enum.GetNames(_enum.GetType());
        }
    }
}
