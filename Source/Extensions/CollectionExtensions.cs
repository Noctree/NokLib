using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Calls Dispose on all items in the collection, then clears it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void DisposeObjects<T>(this ICollection<T> collection) where T : IDisposable
        {
            foreach (var obj in collection)
                obj.Dispose();
            collection.Clear();
        }

        /// <summary>
        /// Calls the disposeFunction with each item in the collection and then clears the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="disposeFunction"></param>
        public static void DisposeWith<T>(this ICollection<T> collection, Action<T> disposeFunction)
        {
            foreach (var item in collection)
                disposeFunction(item);
            collection.Clear();
        }

        /// <summary>
        ///  Formats the collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static string ToCollectionString<T>(this ICollection<T> collection)
        {
            const string separator = ", ";
            var sb = StringBuilderPool.Get();
            sb.Append('(');
            foreach (var item in collection) {
                sb.Append(item.SafeToString());
                sb.Append(separator);
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(')');
            string result = sb.ToString();
            StringBuilderPool.Release(sb);
            return result;
        }
    }
}
