using System;
using System.Collections.Generic;
using System.Linq;

namespace NokLib
{
    public class WeightedRandom<T> : WeightedRandomBase<T, int>
    {
        protected IRandomProvider rng;
        public WeightedRandom(Dictionary<T, int> weights, IRandomProvider randomProvider) : base(weights)
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
            foreach (var entry in Weights) {
                if (weight <= entry.Value)
                    return entry.Key;
                weight -= entry.Value;
            }

            // Should never come here, this is just for the compiler not to complain
            throw new Exception("Failed to choose a random element from the collection based on weight of " + weight);
        }

        protected override int SumWeights(IEnumerator<int> weights) => Weights.Values.Sum();
    }
}
