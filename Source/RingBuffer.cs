using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    /// <summary>
    /// A generic ring buffer, elements are ordered oldest to newest, oldest element at index 0
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RingBuffer<T> : ICollection<T?>
    {
        private readonly T?[] buffer;
        private int index = 0;
        public int Size => buffer.Length;

        public int Count => Size;

        public bool IsReadOnly => false;

        public RingBuffer(int size)
        {
            buffer = new T[size];
        }

        public T? this[int index] {
            get {
                if (index < -Size || index > Size)
                    throw new ArgumentOutOfRangeException(nameof(index));
                if (index < 0)
                    return buffer[buffer.Length - 1 - ((this.index + index) % buffer.Length)];
                return buffer[(this.index + index) % buffer.Length];
            }
            set {
                if (index < -Size || index > Size)
                    throw new ArgumentOutOfRangeException(nameof(index));
                if (index < 0)
                    buffer[buffer.Length - 1 - ((this.index + index) % buffer.Length)] = value;
                buffer[(this.index + index) % buffer.Length] = value;
            }
        }

        public void Add(T? value)
        {
            buffer[index] = value;
            index = (index + 1) % Size;
        }

        public void AddRange(ICollection<T?> collection)
        {
            foreach (var item in collection)
                Add(item);
        }

        public IEnumerator<T?> GetEnumerator() => Enumerate().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Enumerate().GetEnumerator();

        private IEnumerable<T?> Enumerate()
        {
            int size = Size;
            for (int i = 0; i < size; i++) {
                yield return buffer[(index + i) % size];
            }
        }

        public void Clear()
        {
            for (int i = 0; i < buffer.Length; i++) {
                buffer[i] = default;
            }
            index = 0;
        }

        public bool Contains(T? item)
        {
            for (int i = 0; i < buffer.Length; i++) {
                var value = buffer[i];
                if (value != null && value.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T?[] array, int arrayIndex)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            for (int i = 0; i < buffer.Length && arrayIndex < array.Length; i++) {
                array[arrayIndex] = buffer[(index + i) % buffer.Length];
                ++arrayIndex;
            }
        }

        public bool Remove(T? item)
        {
            throw new NotSupportedException("Removal of items from " + nameof(RingBuffer<T>) + " is not supported");
        }
    }
}
