using System;
using System.Collections.Generic;
using System.Linq;

namespace NokLib
{
    public abstract class WeightedRandomBase<T, W> where W : struct, IComparable, IConvertible, IFormattable, IComparable<W>, IEquatable<W>
    {
        protected W WeightSum;
        protected List<ValueTuple<T, W>> Weights;
        protected WeightedRandomBase(IEnumerable<ValueTuple<T, W>> weights)
        {
            this.Weights = new List<ValueTuple<T, W>>(weights);
            WeightSum = SumWeights(this.Weights);
        }

        public void SetWeights(IEnumerable<ValueTuple<T, W>> newWeights)
        {
            Weights.Clear();
            Weights.AddRange(newWeights);
            SumWeights(Weights);
        }

        public void AddWeight(W weight, T obj)
        {
            Weights.Add((obj, weight));
            SumWeights(Weights);
        }

        public void RemoveByObject(T obj)
        {
            if (obj is null)
                return;
            for (int i = 0; i < Weights.Count; i++)
            {
                var value = Weights[i];
                if (value.Item1 != null && value.Item1.Equals(obj))
                {
                    Weights.RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveByWeight(W weight)
        {
            for (int i = 0; i < Weights.Count; i++)
            {
                var value = Weights[i];
                if (value.Item2.Equals(weight))
                {
                    Weights.RemoveAt(i);
                    --i;
                }
            }
            SumWeights(Weights);
        }

        public IReadOnlyList<ValueTuple<T, W>> GetWeights()
        {
            return Weights;
        }
        public abstract T Select(W weight);

        protected abstract W SumWeights(IReadOnlyList<ValueTuple<T, W>> weights);
    }
}
