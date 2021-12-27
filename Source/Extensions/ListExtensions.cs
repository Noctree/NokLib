using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class ListExtensions
    {
        public static void SetLast<T>(this IList<T> list, T value) => list[list.Count - 1] = value;
        public static void Set<T>(this IList<T> list, int index, T value)
        {
            if (index < 0)
                list[list.Count - 1 - index] = value;
            else
                list[index] = value;
        }

        public static void UnboundSet<T>(this IList<T> list, int index, T value)
        {
            if (index < 0)
                list[list.Count - 1 - index % list.Count] = value;
            else
                list[index % list.Count] = value;
        }


        public static T Get<T>(this IList<T> list, int index)
        {
            if (index < 0)
                return list[list.Count - 1 - index];
            return list[index];
        }

        public static T UnboundGet<T>(this IList<T> list, int index)
        {
            if (index < 0)
                return list[list.Count - 1 - index % list.Count];
            return list[index % list.Count];
        }
    }
}
