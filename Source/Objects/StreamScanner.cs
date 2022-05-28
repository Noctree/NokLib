using System;
using System.IO;

namespace NokLib
{
    /// <summary>
    /// Utility for easier stream reading
    /// </summary>
    public class StreamScanner : IDisposable
    {
        /// <summary>
        /// Returns a new instance of a StreamScanner, reading from Console Standard Input
        /// </summary>
        public static StreamScanner ConsoleStreamScanner => new StreamScanner(Console.OpenStandardInput());
        private const string NUMBER_DELIMITERS = ".,";
        private readonly StreamReader reader;
        private bool disposedValue;

        /// <summary>
        /// Creates new StreamScanner for the specified stream
        /// </summary>
        /// <param name="inputStream">The stream the scanner will use, must support reading</param>
        public StreamScanner(Stream inputStream) {
            if (!inputStream.CanRead)
                throw new ArgumentException($"{nameof(inputStream)} must be readable");
            reader = new StreamReader(inputStream);
        }

        /// <summary>
        /// Creates new StreamReader from the BaseStream of the provided StreamReader
        /// </summary>
        /// <param name="reader"></param>
        public StreamScanner(StreamReader reader) : this(reader.BaseStream) { }

        /// <summary>
        /// Reads the stream until EoF, or newline character
        /// </summary>
        /// <returns></returns>
        public string ReadLine() {
            return reader.ReadLine() ?? String.Empty;
        }

        /// <summary>
        /// Reads next character from the stream, throws an exception if reading fails
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EndOfStreamException"></exception>
        /// <exception cref="IOException"></exception>
        public char Read() {
            int result = reader.Read();
            return result == -1 ? ThrowStreamError() : (char)result;
        }

        /// <summary>
        /// Reads next character from the stream
        /// </summary>
        /// <param name="character"></param>
        /// <returns>Returns true if the read was successful</returns>
        public bool TryRead(out char character) {
            int result = reader.Read();
            character = (char)result;
            return result != -1;
        }

        /// <summary>
        /// Reads next integer from the stream
        /// </summary>
        /// <returns></returns>
        public int ReadInt() {
            bool negative = false;
            if (reader.Peek() == '-') {
                negative = true;
                reader.Read();
            }
            int result = (int)InternalNumberRead(int.MaxValue);
            return negative ? -result : result;
        }

        /// <summary>
        /// Reads next long from the stream
        /// </summary>
        /// <returns></returns>
        public long ReadLong() {
            bool negative = false;
            if (reader.Peek() == '-') {
                negative = true;
                reader.Read();
            }
            long result = InternalNumberRead(long.MaxValue);
            return negative ? -result : result;
        }

        /// <summary>
        /// Reads the next double from the stream
        /// </summary>
        /// <param name="delimiters">Valid delimiters used for decimal place</param>
        /// <returns></returns>
        public double ReadDouble(string delimiters = NUMBER_DELIMITERS) {
            long major = 0, minor = 0;
            bool negative = false;
            if (reader.Peek() == '-') {
                negative = true;
                reader.Read();
            }

            while (!reader.EndOfStream && char.IsDigit((char)reader.Peek())) {
                major *= 10;
                major += int.Parse(Read().ToString());
            }

            if (!delimiters.Contains((char)reader.Peek())) {
                return negative ? -major : major;
            }
            reader.Read();
            byte digitCount = 0;
            while (!reader.EndOfStream && char.IsDigit((char)reader.Peek())) {
                ++digitCount;
                minor *= 10;
                minor += int.Parse(Read().ToString());
            }
            double result = major + (minor / (Math.Pow(10, digitCount)));
            return negative ? -result : result;
        }

        private long InternalNumberRead(long maxNumber) {
            long maxNumberRounded = maxNumber - (maxNumber % 10);
            byte maxLastDigit = (byte)(maxNumber % 10);
            long result = 0;
            while (!reader.EndOfStream && char.IsDigit((char)reader.Peek())) {
                result *= 10;
                if (result == maxNumberRounded) {
                    int lastDigit = Read() - '0';
                    if (lastDigit > maxLastDigit)
                        return result / 10;
                    else
                        return result + lastDigit;
                }
                else {
                    result += Read() - '0';
                }
            }
            return result;
        }

        private char ThrowStreamError() {
            if (reader.EndOfStream)
                throw new EndOfStreamException();
            else
                throw new IOException("Failed to read the stream for unknown reason");
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects)
                }

                reader.Dispose();
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~StreamScanner()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// Release resources used by the StreamScanner object
        /// </summary>
        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
