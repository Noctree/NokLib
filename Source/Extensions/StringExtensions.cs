using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the string to a unicode byte array using Encoding.Unicode.GetBytes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToUnicodeByteArray(this string str) => Encoding.Unicode.GetBytes(str);

        /// <summary>
        /// Converts the string to a unicode byte array using Encoding.ASCII.GetBytes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToAsciiByteArray(this string str) => Encoding.ASCII.GetBytes(str);

        /// <summary>
        ///  Appends suffix to string if it doesn't end with it
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AppendIfMissing(this string str, string suffix)
        {
            if (str.EndsWith(suffix))
                return str;
            else
                return string.Concat(str, suffix);
        }

        /// <summary>
        /// Prepends prefix to string if it doesn't start with it
        /// </summary>
        /// <param name="str"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string PrependIfMissing(this string str, string prefix)
        {
            if (str.StartsWith(prefix))
                return str;
            else
                return string.Concat(prefix, str);
        }

        /// <summary>
        /// If string is longer than maxLength a substring of length maxLength is returned, otherwise string is unchanged
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength">Maximum length of the string</param>
        /// <returns></returns>
        public static string TrimIfLongerThan(this string str, int maxLength)
        {
            if (str.Length > maxLength)
                return str.Substring(0, maxLength);
            return str;
        }

        /// <summary>
        /// Replaces all \ with / for compatibility
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FixWindowsPath(this string str)
        {
            return str.Replace('\\', '/');
        }

        /// <summary>
        /// Replaces all / with \ for Windows compatibility, useful when using the Windows Registry
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string WindowsifyPath(this string str)
        {
            return str.Replace('/', '\\');
        }
    }
}
