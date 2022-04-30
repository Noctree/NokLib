using System;
using System.Collections.Generic;
using System.Linq;

namespace NokLib
{
    public class WeightedRandom<T> : WeightedRandomBase<T, int> where T : notnull
    {
        protected IRandomProvider rng;
        public WeightedRandom(IEnumerable<ValueTuple<T, int>> weights, IRandomProvider randomProvider) : base(weights)
        {
            rng = randomProvider;
        }
        public T SelectRandom()
        {
            var target = Interpolation.Linear(0, WeightSum, (float)rng.Percentage());
            return Select(target);
        }

        public override T Select(int weight)
        {
            for (int i = 0; i < Weights.Count; ++i) {
                var entry = Weights[i];
                if (weight <= entry.Item2)
                    return entry.Item1;
                weight -= entry.Item2;
            }

            // Should never come here, this is just for the compiler not to complain
            throw new Exception("Failed to choose a random element from the collection based on weight of " + weight);
        }

        protected override int SumWeights(IReadOnlyList<ValueTuple<T, int>> weights)
        {
            int sum = 0;
            for (int i = 0; i < weights.Count; i++)
                sum += weights[i].Item2;
            return sum;
        }
    }
}
