using System;

namespace NokLib.Parsers
{
    public class FastByteParser : IParser<byte>
    {
        public static readonly FastByteParser Instance = new FastByteParser();

        public byte Parse(string input) {
            if (TryParse(input, out var result))
                return result;
            else
                throw new FormatException();
        }
        public bool TryParse(string input, out byte result) {
            result = 0;
            if (string.IsNullOrEmpty(input) || input.Length > 3)
                return false;

            if (!NumberParser.TryParseNumber(input.AsSpan(), byte.MaxValue, out ulong rawResult))
                return false;
            result = (byte)rawResult;
            return true;
        }

        public static bool TryParseS(string input, out byte result) => Instance.TryParse(input, out result);
    }
}
