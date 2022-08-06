using System;
using System.Collections.Generic;

namespace NokLib;

public class WeightedRandomF<T> : WeightedRandomBase<T, double>
{
    protected IRandomProvider rng;
    public WeightedRandomF(IEnumerable<ValueTuple<T, double>> weights, IRandomProvider randomProvider) : base(weights) {
        rng = randomProvider;
    }

    public T SelectRandom() {
        var target = Interpolation.Linear(0, WeightSum, rng.Percentage());
        return Select(target);
    }

    public override T Select(double weight) {
        for (int i = 0; i < Weights.Count; ++i) {
            var entry = Weights[i];
            if (weight <= entry.Item2)
                return entry.Item1;
            weight -= entry.Item2;
        }

        // Should never come here, this is just for the compiler not to complain
        throw new Exception("Failed to choose a random element from the collection based on weight of " + weight);
    }

    protected override double SumWeights(IReadOnlyList<ValueTuple<T, double>> weights) {
        double sum = 0;
        for (int i = 0; i < weights.Count; i++)
            sum += weights[i].Item2;
        return sum;
    }
}
