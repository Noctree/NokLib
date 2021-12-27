using System;
using System.Collections.Generic;
using System.Linq;

namespace NokLib
{
    public abstract class WeightedRandomBase<T, W> where W : struct, IComparable, IConvertible, IFormattable, IComparable<W>, IEquatable<W>
    {
        protected W WeightSum;
        protected Dictionary<T, W> Weights;
        public WeightedRandomBase(Dictionary<T, W> weights)
        {
            this.Weights = weights;
            WeightSum = SumWeights(weights.Values.GetEnumerator());
        }

        public void SetWeights(Dictionary<T, W> weights)
        {
            this.Weights.Clear();
            this.Weights = weights;
            SumWeights(weights.Values.GetEnumerator());
        }

        public void AddWeight(W weight, T obj)
        {
            this.Weights.Add(obj, weight);
            SumWeights(Weights.Values.GetEnumerator());
        }

        public void RemoveWeightByObject(T obj)
        {
            this.Weights.Remove(obj);
        }

        public void RemoveWeight(W weight)
        {
            var toRemove = Weights.Where(pair => pair.Value.Equals(weight)).Select(pair => pair.Key).ToList();
            toRemove.ForEach(obj => Weights.Remove(obj));
            SumWeights(Weights.Values.GetEnumerator());
        }

        public Dictionary<T, W> GetWeights()
        {
            return new Dictionary<T, W>(Weights);
        }
        public abstract T Select(W weight);

        protected abstract W SumWeights(IEnumerator<W> weights);
    }
}
