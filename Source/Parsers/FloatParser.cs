using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NokLib.Parsers
{
    public class FloatParser : INumericParser<float>
    {
        public static readonly FloatParser Instance = new FloatParser();

        public float Parse(string input) => float.Parse(input.Replace(',', '.'));
        public float Parse(string input, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? formatProvider = null) => float.Parse(input.Replace(',', '.'), style, formatProvider);

        public bool TryParse(string input, NumberStyles style, IFormatProvider? formatProvider, out float result) => float.TryParse(input.Replace(',', '.'), style, formatProvider, out result);

        public bool TryParse(string input, out float result) => TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out result);
    }
}
