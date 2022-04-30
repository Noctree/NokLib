using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NokLib.Parsers
{
    public class DoubleParser : INumericParser<double>
    {
        public static readonly DoubleParser Instance = new DoubleParser();

        public double Parse(string input) => double.Parse(input.Replace(',', '.'));
        public double Parse(string input, NumberStyles style = NumberStyles.None, IFormatProvider? formatProvider = null) => double.Parse(input.Replace(',', '.'), style, formatProvider);

        public bool TryParse(string input, NumberStyles style, IFormatProvider? formatProvider, out double result)
        {
            return double.TryParse(input.Replace(',', '.'), style, formatProvider, out result);
        }

        public bool TryParse(string input, out double result) => TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out result);
    }
}
