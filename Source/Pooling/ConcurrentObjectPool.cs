using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace NokLib.Pooling
{
    /// <summary>
    /// A thread-safe version of the ObjectPool
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConcurrentObjectPool<T> : ObjectPoolBase<T> where T : class
    {
        protected ConcurrentStack<T> stack;
        protected override int StackCount => stack.Count;

        public ConcurrentObjectPool(Func<T> createObject = null, Action<T> onGet = null, Action<T> onRelease = null, Action<T> onDispose = null, int capacity = DEFAULT_MAX_CAPACITY, int initialAllocation = DEFAULT_INIT_ALLOCATION, bool collectionCheck = DEFAULT_COLLECTION_CHECK) : 
            base(createObject, onGet, onRelease, onDispose, capacity, initialAllocation, collectionCheck) { }

        public override bool HasBeenReturned(T obj)
        {
            foreach (var item in stack)
                if (item.Equals(obj))
                    return true;
            return false;
        }

        protected override IEnumerable<T> StackAsEnumerable() => stack;

        protected override void StackClear() => stack.Clear();
        protected override T StackPop()
        {
            if (!stack.TryPop(out T obj)) {
                throw new ConcurrentException("Failed to retrieve object from the internal stack");
            }
            return obj;
        }
        protected override bool StackTryPop(out T obj) => stack.TryPop(out obj);
        protected override void StackPush(T obj) => stack.Push(obj);
    }
}
