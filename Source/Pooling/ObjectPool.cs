using System;
using System.Collections.Generic;

namespace NokLib
{
    /// <summary>
    /// A generic, stack-based object pool
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> : ObjectPoolBase<T> where T : class
    {
        protected Stack<T> stack;
        protected override int StackCount => stack.Count;

        /// <summary>
        /// Create a new ObjectPool
        /// </summary>
        /// <param name="onDispose">Used for disposal of the object</param>
        /// <param name="createObject">Function for allocating new objects, if not specified new instances will be created using the Activator.CreateInstance method</param>
        /// <param name="onGet">Gets called when an object is rented</param>
        /// <param name="onRelease">Gets called when an object is released</param>
        /// <param name="capacity">The maximum allowed capacity of the pool</param>
        /// <param name="initialAllocation">How many objects to preallocate whent the pool is created</param>
        /// <param name="collectionCheck">Prevents an object from being returned twice</param>
        public ObjectPool(Action<T> onDispose, Func<T>? createObject = null, Action<T>? onGet = null, Action<T>? onRelease = null, int capacity = DEFAULT_MAX_CAPACITY, bool collectionCheck = DEFAULT_COLLECTION_CHECK) :
            base(onDispose, createObject, onGet, onRelease, capacity, collectionCheck) {
            stack = new Stack<T>();
        }

        ///<inheritdoc cref="ObjectPoolBase{T}.PreAllocate(int)"/>
        public new void PreAllocate(int amount) => base.PreAllocate(amount);

        public override bool HasBeenReturned(T obj) => stack.Contains(obj);

        protected override IEnumerable<T> StackAsEnumerable() => stack;

        protected override void StackClear() => stack.Clear();

        protected override T StackPop() => stack.Pop();
        protected override bool StackTryPop(out T? obj) => stack.TryPop(out obj);

        protected override void StackPush(T obj) {
            stack.Push(obj);
            if (stack.Count == Capacity)
                stack.TrimExcess();
        }
    }
}
