using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NokLib.Parsers
{
    public class DecimalParser : INumericParser<decimal>
    {
        public static readonly DecimalParser Instance = new DecimalParser();
        public bool TryParse(string input, NumberStyles style, IFormatProvider formatProvider, out decimal result)
        {
            if (input.Contains(','))
                input = input.Replace(',', '.');
            return decimal.TryParse(input, style, formatProvider, out result);
        }

        public bool TryParse(string input, out decimal result) => TryParse(input, NumberStyles.Number, NumberFormatInfo.CurrentInfo, out result);
    }
}
