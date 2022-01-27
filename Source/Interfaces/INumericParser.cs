using System;
using System.Collections.Generic;
using System.Text;

namespace NokLib
{
    public interface INumericParser<T> : IParser<T>
    {
#nullable enable
        /// <summary>
        /// Parses a string representation of a number, supports formatting trough NumberStyles and optionally IFormatProvider
        /// </summary>
        /// <param name="input"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryParse(string input, System.Globalization.NumberStyles style, IFormatProvider? formatProvider, out T result);
#nullable disable
    }
}
