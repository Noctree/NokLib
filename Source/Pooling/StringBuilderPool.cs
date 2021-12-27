using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib.Pooling
{
    public static class StringBuilderPool
    {
        private const int STRINGBUILDER_DEFAULT_CAPACITY = 16;
        public static int StrigBuilderLengthDeallocationThreshold { get; set; } = 1024;

        private static ObjectPool<StringBuilder> ObjectPool = new ObjectPool<StringBuilder>(Create, OnGet, OnRelease, null);
        private static StringBuilder Create() => new StringBuilder();
        private static void OnRelease(StringBuilder sb)
        {
            if (sb.Length > StrigBuilderLengthDeallocationThreshold) {
                sb.Length = 0;
                sb.Capacity = 0;
            }
        }

        private static void OnGet(StringBuilder sb)
        {
            if (sb.Capacity == 0)
                sb.Capacity = STRINGBUILDER_DEFAULT_CAPACITY;
        }

        public static StringBuilder Get() => ObjectPool.Get();
        public static void Release(StringBuilder sb) => ObjectPool.Release(sb);
        public static void Clear() => ObjectPool.Clear();
    }
}
