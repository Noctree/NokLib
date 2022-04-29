using System;
using System.Collections.Generic;
using System.Text;

namespace NokLib.Parsers
{
    /// <summary>
    /// Integer parser implementing the IParser interface
    /// </summary>
    public class FastUIntParser : IParser<uint>
    {
        /// <summary>
        /// Global instance of IntParser
        /// </summary>
        public static readonly FastUIntParser Instance = new FastUIntParser();
        public uint Parse(string input)
        {
            if (TryParse(input, out var result))
                return result;
            else
                throw new FormatException();
        }
        public bool TryParse(string input, out uint result)
        {
            var op_result = NumberParser.TryParseNumber(input.AsSpan(), uint.MaxValue, out ulong result_raw);
            result = (uint)result_raw;
            return op_result;
        }

        /// <summary>
        /// Static syntax sugar method for calling IntParser.Instance.TryParse
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParseS(string input, out uint result) => Instance.TryParse(input, out result);
    }
}
