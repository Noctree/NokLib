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
    }
}
