using System;
using System.Runtime.CompilerServices;

namespace NokLib
{
    public static class UnsafeExtensions
    {
        /// <summary>
        /// Converts boolean to an integer (false = 0, true = 1) trough pointer magic, which is as fast as it can get (one processor instruction)
        /// </summary>
        /// <see href="https://sharplab.io/#v2:C4LghgzgtgPgAgJgIwFgBQcDMACR2DC2A3utmbjnACzYCyAFAJTGnlsBGA9pwDbbsBebAFEAdgDcAlgCdOoqAFNRwAHTCAHpOD5OAEwXYBQgAwBuVmzKTl2MIZESZcxcpUAVSQGMA1joCuyuZoluTWwNie9gBsAJxBIVY20goQfjzhQpEA1LbYAFT8KgCCEABCAJ7ACkzxCXBIMfTJqemMtWQAvhbY6F1o6Fi4SFG4CHSSEJ4aVaIQknIQLMHkg/UjARBgAGYGYdglFVX0wAAWE/zcfFy8CmCizCTLIXAA7Pn07JUKeYwAZNc8W6idrYPpsbqrYbYDbbXY2EoASWUxzOiwBFxudwe3TYr3enyqP3+lyBILB5AhlChMJ2/C++zKXwAcmBJOJqqdzuiAUDsU9LHieXcAPzYD5fRhIbAgMUEhSMMzdclkSlDdazWHYPaI5QAHjcAD4Uec3NhxGAeMwAO4nBTJbCmmUQYDSPyeYAAGgcfigSwSuDe9DCjHNPDJvSAA=="/>
        /// <param name="boolean"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int ToIntFast(this bool boolean) {
            return *(byte*)&boolean;
        }

        /// <summary>
        /// Converts an enum object to long using pointer magic, which is very fast (usually one processor instruction) 
        /// <see href="https://stackoverflow.com/a/61004509">Credit</see>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe long ToLongFast<T>(this T value) where T : unmanaged, Enum {
            if (sizeof(T) == 1)
                return *(byte*)(&value);
            else if (sizeof(T) == 2)
                return *(short*)(&value);
            else if (sizeof(T) == 4)
                return *(int*)(&value);
            else if (sizeof(T) == 8)
                return *(long*)(&value);
            else
                throw new ArgumentException("Argument is not a usual enum type; it is not 1, 2, 4, or 8 bytes in length.");
        }

        /// <summary>
        /// Converts an enum object to int using pointer magic, which is very fast (usually one processor instruction) 
        /// <see href="https://stackoverflow.com/a/61004509">Credit</see>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <exception cref="TypeMismatchException">Thrown when the enum type is backed by an 8 byte value (eg. long/ulong), as int fits only 4 bytes</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int AsIntFast<T>(this T value) where T : unmanaged, Enum {
            if (sizeof(T) == 1)
                return *(byte*)(&value);
            else if (sizeof(T) == 2)
                return *(short*)(&value);
            else if (sizeof(T) == 4)
                return *(int*)(&value);
            else if (sizeof(T) == 8)
                throw new UnsupportedTypeException("Enums of type long/ulong are not supported (too large to fit in int)");
            else
                throw new ArgumentException("Argument is not a usual enum type; it is not 1, 2, 4, or 8 bytes in length.");
        }
    }
}
