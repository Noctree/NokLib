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
        public MovingAverage(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Must greater than 0");
            buffer = new RingBuffer<double>(count);
            sum = default;
            count = 0;
        }

        public double Add(double next)
        {
            sum = sum - buffer[0] + next;
            if (count < buffer.Size)
                count++;
            buffer.Add(next);
            Average = sum / count;
            return Average;
        }

        public double AddRange(ICollection<double> next)
        {
            foreach (var item in next)
                Add(item);
            return Average;
        }

        public void Clear()
        {
            buffer.Clear();
            sum = 0;
            count = 0;
            Average = 0;
        }
    }
}
