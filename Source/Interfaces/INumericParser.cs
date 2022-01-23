using System;
using System.Collections.Generic;
using System.Text;

namespace NokLib
{
    public interface INumericParser<T> : IParser<T>
    {
        public bool TryParse(string input, System.Globalization.NumberStyles style, IFormatProvider? formatProvider, out T result);
        public bool TryParse(string input, out T result);
    }
}
