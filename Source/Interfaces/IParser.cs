using System;

namespace NokLib
{
    /// <summary>
    /// Interface for implementing custom string parsers
    /// </summary>
    /// <typeparam name="T">Type this parser is able to parse</typeparam>
    public interface IParser<T>
    {
        /// <summary>
        /// Tries to convert a string representation of T into an instance of T
        /// </summary>
        /// <param name="input">string representation of an object</param>
        /// <param name="result">Parser result</param>
        /// <returns>True if parsing was successful</returns>
        /// <exception cref="FormatException">Thrown when the input string couldn't be successfully parsed</exception>
        public bool TryParse(string input, out T result);

        /// <summary>
        /// Converts a string representation of T into an instance of T, throws a FormatException if parsing fails
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="FormatException">Thrown when the parsing fails</exception>
        public T Parse(string input);
    }
}
