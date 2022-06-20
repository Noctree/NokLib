using System;

namespace NokLib
{
    public class PooledObject<T> : IDisposable where T : class
    {
        private readonly ObjectPoolBase<T> pool;
        private bool disposedValue;

        public T Object { get; }
        public bool Released => disposedValue;
        public PooledObject(T pooledObject, ObjectPoolBase<T> objectPool) {
            pool = objectPool;
            Object = pooledObject;
        }

        public void Release() => Dispose();

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                disposedValue = true;
                pool.Release(Object);
            }
        }

        ~PooledObject() {
            Dispose(disposing: false);
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public override string? ToString() => Object.ToString();
        public override int GetHashCode() => Object.GetHashCode();
    }
}
