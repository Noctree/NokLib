using System;
using System.Reflection;

namespace NokLib;

/// <summary>
/// Adapter for System.Random to be compatible with IRandomProvider interface
/// </summary>
public class SystemRandom : IRandomProvider
{
    private static bool failedGetGenerateSeedMethod;
    private static Func<int>? SysRandGenSeedMethodDelegate = null;
    protected Random Random;

    /// <summary>
    /// Creates a new instance of SystemRandom with a random seed, the seed is generated with the same method the System.Random class uses
    /// </summary>
    public SystemRandom() : this(GenerateSeed()) { }

    public SystemRandom(int seed) {
        Seed = seed;
        Random = new Random(seed);
    }
    /// <summary>
    /// Is the seed known? Returns false if generator was created without specifying seed, or reset.
    /// </summary>
    /// <remarks>Relevant only for versions NetCore 6.0 or higher, where System.Random seed generation was changed drastically</remarks>
    public bool SeedKnown { get; private set; } = true;
    public long Seed { get; protected set; }
    public bool InclusiveMinimum => true;
    public bool InclusiveMaximum => false;

    protected static int GenerateSeed() {
        if (failedGetGenerateSeedMethod)
            return 0;
        if (SysRandGenSeedMethodDelegate is null) {
            MethodInfo? methodInfo = typeof(System.Random).GetMethod("GenerateSeed", BindingFlags.Static | BindingFlags.NonPublic);
            if (methodInfo is null) {
                failedGetGenerateSeedMethod = true;
                return 0;
            }
            SysRandGenSeedMethodDelegate = (Func<int>)methodInfo.CreateDelegate(typeof(Func<int>));
        }
        return SysRandGenSeedMethodDelegate();
    }

    /// <summary>
    /// Reinitializes the random number generator with a new generated seed
    /// </summary>
    public void ResetSeed() {
        Seed = GenerateSeed();
        SeedKnown = true;
        if (failedGetGenerateSeedMethod) {
            Random = new Random();
            SeedKnown = false;
        }
        else {
            Random = new Random((int)Seed);
        }
    }
    public void SetSeed(long seed) {
        if (seed != Seed) {
            Random = new Random((int)seed);
            Seed = (int)seed;
            SeedKnown = true;
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
