using System;
using System.Globalization;

namespace NokLib.Parsers;

public class DecimalParser : INumericParser<decimal>
{
    public static readonly DecimalParser Instance = new DecimalParser();

    public decimal Parse(string input) => decimal.Parse(input.Replace(',', '.'));

    public decimal Parse(string input, NumberStyles style = NumberStyles.Number, IFormatProvider? formatProvider = null) => decimal.Parse(input.Replace(',', '.'), style, formatProvider);

    public bool TryParse(string input, NumberStyles style, IFormatProvider? formatProvider, out decimal result) => decimal.TryParse(input.Replace(',', '.'), style, formatProvider, out result);

    public bool TryParse(string input, out decimal result) => TryParse(input, NumberStyles.Number, NumberFormatInfo.CurrentInfo, out result);
}
