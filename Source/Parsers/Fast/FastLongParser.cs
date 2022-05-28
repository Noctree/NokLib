using System;

namespace NokLib.Parsers
{
    public class FastLongParser : IParser<long>
    {
        private const ulong MinLongValue = 9223372036854775808;
        public static readonly FastLongParser Instance = new FastLongParser();

        public long Parse(string input) {
            if (TryParse(input, out var result))
                return result;
            else
                throw new FormatException();
        }

        public bool TryParse(string input, out long result) {
            result = 0;
            if (string.IsNullOrEmpty(input))
                return false;

            bool negative = input[0] == '-';
            if (!NumberParser.TryParseNumber(input.AsSpan(negative ? 1 : 0), negative ? MinLongValue : (ulong)long.MaxValue, out ulong unsignedResult))
                return false;
            result = negative ? -(long)unsignedResult : (long)unsignedResult;
            return true;
        }

        public static bool TryParseS(string input, out long result) => Instance.TryParse(input, out result);
    }
}
