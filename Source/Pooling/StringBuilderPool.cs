using System.Text;

namespace NokLib;

public static class StringBuilderPool
{
    private const int STRINGBUILDER_DEFAULT_CAPACITY = 16;
    /// <summary>
    /// If released StringBuilders length exceeds this threshold its length and capacity is set to 0 to release its unused memory
    /// </summary>
    public static int StrigBuilderLengthDeallocationThreshold { get; set; } = 1024;

    private static readonly IObjectPool<StringBuilder> ObjectPool = new ConcurrentObjectPool<StringBuilder>(OnRelease, Create, OnGet, null);
    private static StringBuilder Create() => new StringBuilder();
    private static void OnRelease(StringBuilder sb) {
        if (sb.Length > StrigBuilderLengthDeallocationThreshold) {
            sb.Length = 0;
            sb.Capacity = 0;
        }
        sb.Clear();
    }

    private static void OnGet(StringBuilder sb) {
        if (sb.Capacity == 0) {
            sb.Length = STRINGBUILDER_DEFAULT_CAPACITY;
            sb.Capacity = STRINGBUILDER_DEFAULT_CAPACITY;
        }
    }

    public static StringBuilder Get() => ObjectPool.Get();
    public static PooledObject<StringBuilder> SafeGet() => ObjectPool.SafeGet();
    public static bool TryGet(out StringBuilder? sb) => ObjectPool.TryGet(out sb);
    public static bool TrySafeGet(out PooledObject<StringBuilder>? sb) => ObjectPool.TrySafeGet(out sb);
    public static void Release(StringBuilder sb) => ObjectPool.Release(sb);
    public static void Clear() => ObjectPool.Clear();
}
