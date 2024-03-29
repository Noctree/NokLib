﻿using System;
using System.Collections.Generic;

namespace NokLib;

public abstract class ObjectPoolBase<T> : IObjectPool<T> where T : class
{
    protected const int DEFAULT_MAX_CAPACITY = 32;
    protected const bool DEFAULT_COLLECTION_CHECK = true;
    protected Func<T>? createFunc;
    protected Action<T>? onGetFunc;
    protected Action<T>? onReleaseFunc;
    protected Action<T> onDisposeFunc;
    private bool disposedValue;

    public int Capacity { get; protected set; }
    public int Allocated { get; protected set; }
    public int RentedObjects => Capacity - AvailableObjects;
    public int AvailableObjects => StackCount;
    public bool DoDulicateCheck { get; set; }
    protected abstract int StackCount { get; }

    /// <summary>
    /// Create a new ObjectPool
    /// </summary>
    /// <param name="onDispose">Used for disposal of the object</param>
    /// <param name="createObject">Function for allocating new objects, if not specified new instances will be created using the Activator.CreateInstance method</param>
    /// <param name="onGet">Gets called when an object is rented</param>
    /// <param name="onRelease">Gets called when an object is released</param>
    /// <param name="capacity">The maximum allowed capacity of the pool</param>
    /// <param name="doDuplicateCheck">Prevents an object from being returned twice</param>
    protected ObjectPoolBase(Action<T> onDispose, Func<T>? createObject = null, Action<T>? onGet = null, Action<T>? onRelease = null, int capacity = DEFAULT_MAX_CAPACITY, bool doDuplicateCheck = DEFAULT_COLLECTION_CHECK) {
        Capacity = capacity;
        createFunc = createObject;
        onGetFunc = onGet;
        onReleaseFunc = onRelease;
        onDisposeFunc = onDispose;
        DoDulicateCheck = doDuplicateCheck;
    }

    /// <summary>
    /// Preallocates a specified amount of objects, throws an exception if <paramref name="amount"/> exceeds <see cref="Capacity"/>
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="LimitReachedException"></exception>
    protected void PreAllocate(int amount) {
        for (int i = 0; i < amount; i++)
            AllocateNew();
    }

    private void AllocateNew() {
        if (Allocated == Capacity)
            throw new LimitReachedException($"ObjectPool has reached its allocation capacity of {typeof(T).Name}");

        if (createFunc is null)
            StackPush(Activator.CreateInstance<T>());
        else
            StackPush(createFunc());
        ++Allocated;
    }

    /// <summary>
    /// Get a pooled instance of the object, if no allocated instance is available, a new instance is allocated. If there are no allocated instances left and the pools capacity has been reached, a LimitReachedException is thrown
    /// </summary>
    /// <returns>The instanced object</returns>
    public T Get() {
        if (AvailableObjects == 0)
            AllocateNew();

        var rentedObj = StackPop();
        onGetFunc?.Invoke(rentedObj);
        return rentedObj;
    }

    /// <summary>
    /// Get a pooled instance of the object wrapped in PooledObject, use with the 'using' keyword for the object to be automatically released
    /// </summary>
    /// <returns></returns>
    public PooledObject<T> SafeGet() => new PooledObject<T>(Get(), this);

    /// <summary>
    /// Attempt to get a pooled instance of the object, if no allocated instance is available, a new instance is allocated.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>False if a new instance needs to be allocated, but pools capacity has been reached. Otherwise returns true</returns>
    public bool TryGet(out T? obj) {
        obj = null;
        if (AvailableObjects == 0) {
            if (Allocated == Capacity)
                return false;
            AllocateNew();
        }
        return StackTryPop(out obj);
    }

    /// <summary>
    /// Try to get a pooled instance of the object wrapped in PooledObject, use with the 'using' keyword for the object to be automatically released
    /// </summary>
    /// <returns></returns>
    public bool TrySafeGet(out PooledObject<T>? wrappedObj) {
        wrappedObj = null;
        if (!TryGet(out T? obj))
            return false;
        if (obj is null)
            return false;
        wrappedObj = new PooledObject<T>(obj, this);
        return true;
    }

    /// <summary>
    /// Releases the object back to the pool, if DuplicateChecking is enabled and the object has already been released a DuplicateObjectInCollectionException is thrown
    /// </summary>
    /// <param name="obj">The object to be released</param>
    public void Release(T obj) {
        if (DoDulicateCheck && HasBeenReturned(obj))
            throw new DuplicateObjectInCollectionException("This object has already been released");
        onReleaseFunc?.Invoke(obj);
        StackPush(obj);
    }

    /// <summary>
    /// Calls the OnDispose method (if specified) for each allocated object and clears the pool. If no OnDispose method was specified and the item type stored in this pool implements IDisposable interface the objects Dispose method is called instead
    /// </summary>
    public void Clear() {
        bool isDisposable = typeof(T) is IDisposable;
        foreach (var item in StackAsEnumerable())
            onDisposeFunc(item);
        StackClear();
        Allocated = 0;
    }

    /// <summary>
    /// Has the object been returned already?
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public abstract bool HasBeenReturned(T obj);

    /// <summary>
    /// Push to the internal stack
    /// </summary>
    /// <param name="obj"></param>
    protected abstract void StackPush(T obj);
    /// <summary>
    /// Pop from the internal stack
    /// </summary>
    /// <returns></returns>
    protected abstract T StackPop();

    /// <summary>
    /// Try to pop from the internal stack
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    protected abstract bool StackTryPop(out T? obj);
    /// <summary>
    /// Clear the internal stack
    /// </summary>
    protected abstract void StackClear();
    /// <summary>
    /// Get internal stack as enumerable
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerable<T> StackAsEnumerable();

    protected virtual void Dispose(bool disposing) {
        if (!disposedValue) {
            if (disposing) {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            Clear();
            createFunc = null;
            onGetFunc = null;
            onReleaseFunc = null;
#nullable disable
            onDisposeFunc = null;
#nullable enable
            disposedValue = true;
        }
    }

    public void Dispose() {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
