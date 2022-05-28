using System;

namespace NokLib
{
    public interface IObjectPool<T> : IDisposable where T : class
    {
        /// <summary>
        /// Get a pooled instance of an object
        /// </summary>
        /// <returns></returns>
        public T Get();
        /// <summary>
        /// Get a pooled instance of an object using the PooledObject wrapper (use with the 'using' keyword for easy releasing)
        /// </summary>
        /// <returns></returns>
        public PooledObject<T> SafeGet();
        /// <summary>
        /// Tries to get a pooled instance of an object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>False if no objects are available and the pool has reached its capacity</returns>
        public bool TryGet(out T? obj);
        /// <summary>
        /// Tries to get a pooled instance of an object using the PooledObject wrapper
        /// </summary>
        /// <param name="safeObj"></param>
        /// <returns></returns>
        public bool TrySafeGet(out PooledObject<T>? safeObj);
        /// <summary>
        /// Releases the object back to the pool
        /// </summary>
        /// <param name="obj"></param>
        public void Release(T obj);
        /// <summary>
        /// Clears the pool and releases resources used by the pooled objects
        /// </summary>
        public void Clear();
        /// <summary>
        /// Maximum number of allocated objects
        /// </summary>
        public int Capacity { get; }
        /// <summary>
        /// Total number of already allocated objects
        /// </summary>
        public int Allocated { get; }
        /// <summary>
        /// Number of available objects in this pool
        /// </summary>
        public int AvailableObjects { get; }
    }
}
