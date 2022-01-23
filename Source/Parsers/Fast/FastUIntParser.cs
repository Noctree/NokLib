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
        public bool TryParse(string input, out uint result) => NumberParser.TryParseUInt(input.AsSpan(), out result);

        /// <summary>
        /// Static syntax sugar method for calling IntParser.Instance.TryParse
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParseS(string input, out uint result) => Instance.TryParse(input, out result);
    }
}
