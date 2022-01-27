using System;
using System.Collections.Generic;
using System.Text;

namespace NokLib.Pooling
{
    public class PooledObject<T> : IDisposable where T : class
    {
        private readonly ObjectPoolBase<T> pool;
        private bool disposedValue;

        public T Object { get; private set; }
        public PooledObject(T pooledObject, ObjectPoolBase<T> objectPool)
        {
            pool = objectPool;
            Object = pooledObject;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                pool.Release(Object);
                disposedValue = true;
            }
        }

        ~PooledObject()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
