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
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void MinMax<T>(this IEnumerable<T> collection, out T min, out T max) where T : IComparable<T>
        {
            min = max = collection.FirstOrDefault();
            foreach (var item in collection) {
                if (item.CompareTo(min) < 0)
                    min = item;
                else if (item.CompareTo(max) > 0)
                    max = item;
            }
        }

        /// <summary>
        /// Finds both the minimum and maximum of the collection in one pass using the supplied compareFunction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="compareFunction">Comparer function for the items in the collection, should follow the IComparable method (negative result = less, 0 = equal, positive result = greater)</param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void MinMax<T>(this IEnumerable<T> collection, Func<T, T, int> compareFunction, out T min, out T max)
        {
            min = max = collection.FirstOrDefault();
            foreach (var item in collection) {
                if (compareFunction(item, min) < 0)
                    min = item;
                else if (compareFunction(item, max) > 0)
                    max = item;
            }
        }
    }
}
