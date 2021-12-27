using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class StreamExtensions
    {
        public static void StaticWrite(this Stream stream, byte[] data)
        {
            if (stream.CanWrite && stream.CanSeek) {
                long pos = stream.Position;
                stream.Write(data);
                stream.Position = pos;
            } else {
                throw new NotSupportedException("Stream must be seekable and writable");
            }
        }

        public static void StaticWrite(this Stream stream, string str) => stream.StaticWrite(str.ToAsciiByteArray());

        public static void StaticWrite(this Stream stream, object obj) => stream.StaticWrite(obj.ToString());

        public static void Write(this Stream stream, string str)
        {
            if (stream.CanWrite)
                stream.Write(str.ToAsciiByteArray());
            else
                throw new NotSupportedException("Stream must be writable");
        }

        public static void Write(this Stream stream, object obj) => stream.Write(obj.ToString());
    }
}
