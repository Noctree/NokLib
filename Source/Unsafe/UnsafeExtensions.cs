using System;
using System.Runtime.CompilerServices;

namespace NokLib
{
    public static class UnsafeCastingExtensions
    {
        /// <summary>
        /// Converts boolean to an integer (false = 0, true = 1) trough pointer magic, which is as fast as it can get (two processor instructions)
        /// </summary>
        /// <param name="boolean"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int ToIntFast(this bool boolean) {
            return *(byte*)&boolean;
        }

        /// <summary>
        /// Converts an enum object to long using pointer magic, which is very fast
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
        /// <param name="force">Force conversion of types too large to fit into an int, CAN RESULT IN DATA LOSS</param>
        /// <exception cref="TypeMismatchException">Thrown when the enum type is backed by an 8 byte value (eg. long/ulong), as int fits only 4 bytes</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int ToIntFast<T>(this T value, bool force = false) where T : unmanaged, Enum {
            if (sizeof(T) == 1)
                return *(byte*)(&value);
            else if (sizeof(T) == 2)
                return *(short*)(&value);
            else if (sizeof(T) == 4)
                return *(int*)(&value);
            else if (sizeof(T) == 8) {
                if (force)
                    return (int)(*(int*)(&value));
                else
                    throw new UnsupportedTypeException("Enums of type long/ulong are not supported (too large to fit in int)");
            }
            else
                throw new ArgumentException("Argument is not a usual enum type; it is not 1, 2, 4, or 8 bytes in length.");
        }

        /// <summary>
        /// Converts an enum object to long using pointer magic, which is very fast (usually one processor instruction) 
        /// <see href="https://stackoverflow.com/a/61004509">Credit</see>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T ToEnumFast<T>(this long value) where T : unmanaged, Enum {
            if (sizeof(T) == 1) {
                byte cast = (byte)value;
                return *(T*)(&cast);
            }
            else if (sizeof(T) == 2) {
                short cast = (short)value;
                return *(T*)(&cast);
            }
            else if (sizeof(T) == 4) {
                int cast = (int)value;
                return *(T*)(&cast);
            }
            else if (sizeof(T) == 8) {
                return *(T*)(&value);
            }
            else
                throw new ArgumentException("Argument is not a usual enum type; it is not 1, 2, 4, or 8 bytes in length.");
        }

        /// <summary>
        /// Converts an enum object to long using pointer magic, which is very fast (usually one processor instruction) 
        /// <see href="https://stackoverflow.com/a/61004509">Credit</see>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T ToEnumFast<T>(this int value) where T : unmanaged, Enum {
            if (sizeof(T) == 1) {
                byte cast = (byte)value;
                return *(T*)(&cast);
            }
            else if (sizeof(T) == 2) {
                short cast = (short)value;
                return *(T*)(&cast);
            }
            else if (sizeof(T) == 4) {
                return *(T*)(&value);
            }
            else if (sizeof(T) == 8) {
                long cast = (long)value;
                return *(T*)(&cast);
            }
            else
                throw new ArgumentException("Argument is not a usual enum type; it is not 1, 2, 4, or 8 bytes in length.");
        }

        /// <summary>
        /// Converts an enum object to long using pointer magic, which is very fast (usually one processor instruction) 
        /// <see href="https://stackoverflow.com/a/61004509">Credit</see>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T ToEnumFast<T>(this short value) where T : unmanaged, Enum {
            if (sizeof(T) == 1) {
                byte cast = (byte)value;
                return *(T*)(&cast);
            }
            else if (sizeof(T) == 2) {
                return *(T*)(&value);
            }
            else if (sizeof(T) == 4) {
                int cast = (int)value;
                return *(T*)(&cast);
            }
            else if (sizeof(T) == 8) {
                long cast = (long)value;
                return *(T*)(&cast);
            }
            else
                throw new ArgumentException("Argument is not a usual enum type; it is not 1, 2, 4, or 8 bytes in length.");
        }

        /// <summary>
        /// Converts an enum object to long using pointer magic, which is very fast (usually one processor instruction) 
        /// <see href="https://stackoverflow.com/a/61004509">Credit</see>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe T ToEnumFast<T>(this byte value) where T : unmanaged, Enum {
            if (sizeof(T) == 1) {
                return *(T*)(&value);
            }
            else if (sizeof(T) == 2) {
                short cast = (short)value;
                return *(T*)(&cast);
            }
            else if (sizeof(T) == 4) {
                int cast = (int)value;
                return *(T*)(&cast);
            }
            else if (sizeof(T) == 8) {
                long cast = (long)value;
                return *(T*)(&cast);
            }
            else
                throw new ArgumentException("Argument is not a usual enum type; it is not 1, 2, 4, or 8 bytes in length.");
        }
    }
}
