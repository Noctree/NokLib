using System;

namespace NokLib.Parsers;

public class FastSByteParser : IParser<sbyte>
{
    private const byte MinSByteValue = 128;
    public static readonly FastSByteParser Instance = new FastSByteParser();

    public sbyte Parse(string input) => TryParse(input, out var result) ? result : throw new FormatException();
    public bool TryParse(string input, out sbyte result) {
        result = 0;
        if (string.IsNullOrEmpty(input) || input.Length > 4)
            return false;
        bool negative = input[0] == '-';
        if (!NumberParser.TryParseNumber(input.AsSpan(negative ? 1 : 0), negative ? MinSByteValue : (byte)sbyte.MaxValue, out ulong rawResult))
            return false;
        result = (sbyte)(negative ? -(sbyte)rawResult : (sbyte)rawResult);
        return true;
    }

    public static bool TryParseS(string input, out sbyte result) => Instance.TryParse(input, out result);
}
