using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public class MovingAverage
    {
        protected RingBuffer<double> buffer;
        protected double sum;
        protected int count;
        public double Average { get; protected set; }

        /// <summary>
        /// Create a new MovingAverage calculator
        /// </summary>
        /// <param name="size">Size of the internal buffer, bigger size means a longer record of values</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public MovingAverage(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), "Must greater than 0");
            buffer = new RingBuffer<double>(size);
            sum = default;
        }

        /// <summary>
        /// Add another value to the average
        /// </summary>
        /// <param name="next"></param>
        /// <returns>New average</returns>
        public double Add(double next)
        {
            sum = sum - buffer[0] + next;
            if (count < buffer.Size)
                count++;
            buffer.Add(next);
            Average = sum / count;
            return Average;
        }

        public double AddRange(IEnumerable<double> next)
        {
            foreach (var item in next)
                Add(item);
            return Average;
        }

        public void Reset()
        {
            buffer.Clear();
            sum = 0;
            count = 0;
            Average = 0;
        }
    }
}
