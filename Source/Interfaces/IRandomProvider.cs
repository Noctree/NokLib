using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public interface IRandomProvider
    {
        /// <summary>
        /// Returns a new instance of a System.Random class wrapped in NokLib.SystemRandom for IRandomProvider interface compatibility
        /// </summary>
        public static IRandomProvider SystemRandom => new SystemRandom();
        /// <summary>
        /// Returns the seed used by this random number generator
        /// </summary>
        long Seed { get; }

        /// <summary>
        /// Is the lower ĺimit of this random number generator inclusive?
        /// </summary>
        bool InclusiveMinimum { get; }

        /// <summary>
        /// Is The upper limit of this random number generator inclusive?
        /// </summary>
        bool InclusiveMaximum { get; }
        /// <summary>
        /// Sets the seed of this random number generator
        /// </summary>
        /// <param name="seed"></param>
        void SetSeed(long seed);

        /// <summary>
        ///  Generates a non-negative random number
        /// </summary>
        /// <returns></returns>
        int NextInt();
        /// <summary>
        /// Generates a number between 0 and max
        /// </summary>
        /// <param name="max">Upper limit of the generated number range</param>
        /// <returns></returns>
        int NextInt(int max);
        /// <summary>
        /// Generates a number between min and max
        /// </summary>
        /// <param name="min">Lower limit of the generated number range </param>
        /// <param name="max">Upper limit of the generated number range</param>
        int NextInt(int min, int max);

        /// <summary>
        /// Generates a non-negative random number
        /// </summary>
        /// <returns></returns>
        double NextDouble();

        /// <summary>
        /// Generates a number between 0 and max
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        double NextDouble(double max);
        /// <summary>
        /// Generates a number between min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        double NextDouble(double min, double max);
        /// <summary>
        /// Generates a floating point number between 0 and 1
        /// </summary>
        double Percentage();
    }
}
