using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Calls Dispose for each item from the enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void DisposeObjects<T>(this IEnumerable<T> collection) where T : IDisposable
        {
            foreach (var item in collection)
                item.Dispose();
        }

        /// <summary>
        /// For each enumerated item calls the disposeFunction with the item as an argument
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="disposeFunction"></param>
        public static void DisposeObjectsWith<T>(this IEnumerable<T> collection, Action<T> disposeFunction)
        {
            foreach (var item in collection)
                disposeFunction(item);
        }

        /// <summary>
        /// Finds both the minimum and maximum of the collection in one pass
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static ValueTuple<T,T> MinMax<T>(this IEnumerable<T> collection) where T : notnull, IComparable<T>
        {
            if (collection.FirstOrDefault() is null)
                return default;
            T min, max;
            min = max = collection.First();
            foreach (var item in collection) {
                if (item.CompareTo(min) < 0)
                    min = item;
                else if (item.CompareTo(max) > 0)
                    max = item;
            }
            return new ValueTuple<T,T>(min, max);
        }

        /// <summary>
        /// Finds both the minimum and maximum of the collection in one pass using the supplied compareFunction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="compareFunction">Comparer function for the items in the collection, should follow the IComparable method (negative result = less, 0 = equal, positive result = greater)</param>
        public static ValueTuple<T,T> MinMax<T>(this IEnumerable<T> collection, Func<T, T, int> compareFunction)
        {
            if (collection.FirstOrDefault() is null)
                return default;
            T min, max;
            min = max = collection.First();
            foreach (var item in collection) {
                if (compareFunction(item, min) < 0)
                    min = item;
                else if (compareFunction(item, max) > 0)
                    max = item;
            }
            return new ValueTuple<T, T>(min, max);
        }
    }
}
