using System;
using System.Collections.Generic;
using System.Text;

namespace NokLib.Parsers
{
    public class FastIntParser : IParser<int>
    {
        private const uint MinIntValue = 2147483648;
        /// <summary>
        /// Global instance of IntParser
        /// </summary>
        public static readonly FastIntParser Instance = new FastIntParser();
        public bool TryParse(string input, out int result)
        {
            result = 0;
            if (input.Length == 0)
                return false;

            bool negative = input[0] == '-';
            bool opResult = NumberParser.TryParseNumber(input.AsSpan(negative ? 1 : 0), negative? MinIntValue : int.MaxValue, out ulong unsignedResult);
            if (!opResult)
                return false;
            int signedResult = (int)unsignedResult;
            result = negative ? -signedResult : signedResult;
            return true;
        }

        public static bool TryParseS(string input, out int result) => Instance.TryParse(input, out result);
    }
}
