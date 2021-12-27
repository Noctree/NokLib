using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public class WeightedRandomF<T> : WeightedRandomBase<T, double>
    {
        protected IRandomProvider rng;
        public WeightedRandomF(Dictionary<T, double> weights, IRandomProvider randomProvider) : base(weights)
        {
            rng = randomProvider;
        }

        public T SelectRandom()
        {
            var target = Interpolation.Linear(0, WeightSum, rng.Percentage());
            return Select(target);
        }

        public override T Select(double weight)
        {
            foreach (var entry in Weights) {
                if (weight <= entry.Value)
                    return entry.Key;
                weight -= entry.Value;
            }

            // Should never come here, this is just for the compiler not to complain
            throw new Exception("Failed to choose a random element from the collection based on weight of " + weight);
        }

        protected override double SumWeights(IEnumerator<double> weights) => Weights.Values.Sum();
    }
}
