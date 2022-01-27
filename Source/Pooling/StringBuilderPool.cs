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
        /// <summary>
        /// If released StringBuilders length exceeds this threshold its length and capacity is set to 0 to release its unused memory
        /// </summary>
        public static int StrigBuilderLengthDeallocationThreshold { get; set; } = 1024;

        private static readonly IObjectPool<StringBuilder> ObjectPool = new ConcurrentObjectPool<StringBuilder>(Create, OnGet, OnRelease, null);
        private static StringBuilder Create() => new StringBuilder();
        private static void OnRelease(StringBuilder sb)
        {
            if (sb.Length > StrigBuilderLengthDeallocationThreshold) {
                sb.Length = 0;
                sb.Capacity = 0;
            }
            sb.Clear();
        }

        private static void OnGet(StringBuilder sb)
        {
            if (sb.Capacity == 0) {
                sb.Length = STRINGBUILDER_DEFAULT_CAPACITY;
                sb.Capacity = STRINGBUILDER_DEFAULT_CAPACITY;
            }
        }

        public static StringBuilder Get() => ObjectPool.Get();
        public static PooledObject<StringBuilder> SafeGet() => ObjectPool.SafeGet();
        public static bool TryGet(out StringBuilder sb) => ObjectPool.TryGet(out sb);
        public static bool TrySafeGet(out PooledObject<StringBuilder> sb) => ObjectPool.TrySafeGet(out sb);
        public static void Release(StringBuilder sb) => ObjectPool.Release(sb);
        public static void Clear() => ObjectPool.Clear();
    }
}
