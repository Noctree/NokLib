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

        public ConcurrentObjectPool(Action<T> onDispose, Func<T>? createObject = null, Action<T>? onGet = null, Action<T>? onRelease = null, int capacity = DEFAULT_MAX_CAPACITY, bool collectionCheck = DEFAULT_COLLECTION_CHECK) :
            base(onDispose, createObject, onGet, onRelease, capacity, collectionCheck)
        {
            stack = new ConcurrentStack<T>();
        }

        /// <inheritdoc cref="ObjectPoolBase{T}.PreAllocate(int)"/>
        public new void PreAllocate(int amount) => base.PreAllocate(amount);

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
            if (!stack.TryPop(out T? obj)) {
                throw new ConcurrencyException("Failed to retrieve object from the internal stack");
            }
            return obj;
        }
        protected override bool StackTryPop(out T? obj) => stack.TryPop(out obj);
        protected override void StackPush(T obj) => stack.Push(obj);
    }
}
