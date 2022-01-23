using System;
using System.Collections.Generic;
using System.Text;

namespace NokLib.Parsers
{
    public class FastByteParser : IParser<byte>
    {
        public static readonly FastByteParser Instance = new FastByteParser();
        public bool TryParse(string input, out byte result)
        {
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
