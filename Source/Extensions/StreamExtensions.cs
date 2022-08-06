using System;
using System.IO;

namespace NokLib
{
    public static class StreamExtensions
    {
        public static void StaticWrite(this Stream stream, byte[] data) {
            if (stream.CanWrite && stream.CanSeek) {
                long pos = stream.Position;
                stream.Write(data);
                stream.Position = pos;
            }
            else {
                throw new NotSupportedException("Stream must be seekable and writable");
            }
        }

        public static void StaticWrite(this StreamWriter stream, string str) {
            if (stream.BaseStream.CanSeek) {
                long pos = stream.BaseStream.Position;
                stream.Write(str);
                stream.BaseStream.Position = pos;
            }
            else {
                throw new NotSupportedException("StreamWriter.BaseStream must be seekable");
            }
        }

        public static void StaticWriteLine(this StreamWriter stream, string str) {
            if (stream.BaseStream.CanSeek) {
                long pos = stream.BaseStream.Position;
                stream.WriteLine(str);
                stream.BaseStream.Position = pos;
            }
            else {
                throw new NotSupportedException("StreamWriter.BaseStream must be seekable");
            }
        }
    }
}
