using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NokLib.Parsers
{
    public class DoubleParser : INumericParser<double>
    {
        public static readonly DoubleParser Instance = new DoubleParser();
        public bool TryParse(string input, NumberStyles style, IFormatProvider formatProvider, out double result)
        {
            if (input.Contains(','))
                input = input.Replace(',', '.');
            return double.TryParse(input, style, formatProvider, out result);
        }

        public bool TryParse(string input, out double result) => TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out result);
    }
}
