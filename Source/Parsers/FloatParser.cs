using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NokLib.Parsers
{
    public class FloatParser : IParser<float>, INumericParser<float>
    {
        public static readonly FloatParser Instance = new FloatParser();
        public bool TryParse(string input, NumberStyles style, IFormatProvider formatProvider, out float result)
        {
            if (input.Contains(','))
                input = input.Replace(',', '.');
            return float.TryParse(input, style, formatProvider, out result);
        }

        public bool TryParse(string input, out float result) => TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out result);

    }
}
