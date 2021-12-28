using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NokLib {
    public class SystemRandom : IRandomProvider
    {
        private static Func<int> SysRandGenSeedMethodDelegate = null;
        protected Random Random;

        /// <summary>
        /// Creates a new instance of SystemRandom with a random seed, the seed is generated with the same method the System.Random class uses
        /// </summary>
        public SystemRandom() : this(GenerateSeed()) { }

        public SystemRandom(int seed)
        {
            Seed = seed;
            Random = new Random(seed);
        }

        public long Seed { get; protected set; }
        public bool InclusiveMinimum => true;
        public bool InclusiveMaximum => false;

        protected static int GenerateSeed()
        {
            if (SysRandGenSeedMethodDelegate is null) {
                SysRandGenSeedMethodDelegate = (Func<int>)typeof(System.Random).GetMethod("GenerateSeed", BindingFlags.Static | BindingFlags.NonPublic).CreateDelegate(typeof(Func<int>));
            }
            return SysRandGenSeedMethodDelegate();
        }

        /// <summary>
        /// Reinitializes the random number generator with a new generated seed
        /// </summary>
        public void ResetSeed() => SetSeed(GenerateSeed());
        public void SetSeed(long seed)
        {
            if (seed != Seed) {
                Random = new Random((int)seed);
                Seed = (int)seed;
            }
        }

        public double NextDouble() => double.MaxValue * Random.NextDouble();

        public double NextDouble(double max) => max * Random.NextDouble();

        public double NextDouble(double min, double max) => Interpolation.Linear(min, max, Random.NextDouble());

        public int NextInt() => Random.Next();

        public int NextInt(int max) => Random.Next(max);

        public int NextInt(int min, int max) => Random.Next(min, max);

        public double Percentage() => Random.NextDouble();

    }
}
