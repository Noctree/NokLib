using System;
using System.Collections.Generic;
using System.Text;

namespace NokLib.Pooling
{
    public class PooledObject<T> : IDisposable where T : class
    {
        private ObjectPoolBase<T> pool;
        public T Object { get; private set; }
        public PooledObject(T pooledObject, ObjectPoolBase<T> objectPool)
        {
            pool = objectPool;
            Object = pooledObject;
        }
        public void Dispose() => pool.Release(Object);
        ~PooledObject() => Dispose();
    }
}
