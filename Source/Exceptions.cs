using System;

namespace NokLib;

/// <summary>
/// Thrown when a collection limit is reached
/// </summary>
[Serializable]
public class LimitReachedException : Exception
{
    public int? Limit { get; } = null;
    public LimitReachedException(string? message = null) : this(null, message) { }
    public LimitReachedException(int? limit = null, string? message = null) : this(message, null) {
        Limit = limit;
    }
    public LimitReachedException(string? message, Exception? inner) : base(message, inner) { }
    public LimitReachedException() { }
}
/// <summary>
/// Thrown when a collection limit is reached
/// </summary>
[Serializable]
public class LimitReachedException<T> : LimitReachedException
{
    public new T? Limit { get; }
    public T? ActualValue { get; }
    public LimitReachedException(T limit, T actualValue, string? message = null) :
        base(message is null ?
            $"Value {actualValue} exceeds maximum limit {limit}" :
            $"Value {actualValue} exceeds maximum limit {limit} ({message})") {
        Limit = limit;
        ActualValue = actualValue;
    }

    public LimitReachedException(string? message = null) : base(message) { }
    public LimitReachedException(string? message, Exception inner) : base(message, inner) { }
    public LimitReachedException() { }
}

/// <summary>
/// Thrown when a type is not supported by a generic class/method
/// </summary>
[Serializable]
public class UnsupportedTypeException : Exception
{
    public Type? ExpectedType { get; }
    public Type? ActualType { get; }
    /// <summary>
    /// Create a new instance of the exception
    /// </summary>
    public UnsupportedTypeException() { }
    /// <summary>
    /// Create a new instance of the exception with a message describing the cause of the exception
    /// </summary>
    /// <param name="message">Cause of the exception</param>
    public UnsupportedTypeException(string message) : base(message) { }
    /// <summary>
    /// Create a new instance of the exception with a message describing what type is not supported
    /// </summary>
    /// <param name="type">The unsupported type</param>
    public UnsupportedTypeException(Type actualType) : this($"Objects of type {actualType.FullName} are not supported") {
        ActualType = actualType;
    }

    public UnsupportedTypeException(Type actualType, Type expectedType, string? message) : base(message) {
        ExpectedType = expectedType;
        ActualType = actualType;
    }

    public UnsupportedTypeException(string? message, Exception? innerException) : base(message, innerException) { }
}

/// <summary>
/// Thrown when an invalid handle is used
/// </summary>
[Serializable]
public class InvalidHandleException : Exception
{
    /// <summary>
    /// Create a new instance of the exception
    /// </summary>
    public InvalidHandleException() { }
    /// <summary>
    /// Create a new instance of the exception with a message describing the cause of the exception
    /// </summary>
    /// <param name="message">Cause of the exception</param>
    public InvalidHandleException(string message) : base(message) { }

    public InvalidHandleException(string? message, Exception? innerException) : base(message, innerException) { }
}

/// <summary>
/// Thrown when an object has invalid size
/// </summary>
[Serializable]
public class InvalidSizeException : Exception
{
    public int? ExpectedSize { get; } = null;
    public int? ActualSize { get; } = null;
    /// <summary>
    /// Create a new instance of the exception
    /// </summary>
    public InvalidSizeException() { }

    public InvalidSizeException(int expectedSize, int actualSize, string? message) : base(message) {
        ExpectedSize = expectedSize;
        ActualSize = actualSize;
    }

    /// <summary>
    /// Create a new instance of the exception with a message describing the cause of the exception
    /// </summary>
    /// <param name="message">Cause of the exception</param>
    public InvalidSizeException(string message) : base(message) { }

    public InvalidSizeException(string? message, Exception? innerException) : base(message, innerException) { }
}

/// <summary>
/// Thrown when sizes of two array do not match
/// </summary>
[Serializable]
public class SizeMismatchException : Exception
{
    public int SizeOfA { get; }
    public int SizeOfB { get; }
    /// <summary>
    /// Create a new instance of the exception
    /// </summary>
    public SizeMismatchException() { }
    /// <summary>
    /// Create a new instance of the exception with a message describing the cause of the exception
    /// </summary>
    /// <param name="message">Cause of the exception</param>
    public SizeMismatchException(string? message) : base(message) { }
    public SizeMismatchException(int sizeA, int sizeB, string? message = null) : base($"{message ?? "Object sizes do not match"} ({sizeA} != {sizeB})") {
        SizeOfA = sizeA;
        SizeOfB = sizeB;
    }

    public SizeMismatchException(string? message, Exception? innerException) : base(message, innerException) { }
}

/// <summary>
/// Thrown when an attempt to insert an object into a collection already containing it is made
/// </summary>
[Serializable]
public class DuplicateObjectInCollectionException : Exception
{
    /// <summary>
    /// Create a new instance of the exception
    /// </summary>
    public DuplicateObjectInCollectionException() : base("This object is already contained in this collection") { }
    /// <summary>
    /// Create a new instance of the exception with a message describing the cause of the exception
    /// </summary>
    /// <param name="message">Cause of the exception</param>
    public DuplicateObjectInCollectionException(string message) : base(message) { }

    public DuplicateObjectInCollectionException(string? message, Exception? innerException) : base(message, innerException) { }
}

/// <summary>
/// Thrown when an operation fails because of issues connected with concurrency
/// </summary>
[Serializable]
public class ConcurrencyException : Exception
{
    /// <summary>
    /// Create a new instance of the exception
    /// </summary>
    public ConcurrencyException() : base() { }
    /// <summary>
    /// Create a new instance of the exception with a message describing the cause of the exception
    /// </summary>
    /// <param name="message">Cause of the exception</param>
    public ConcurrencyException(string message) : base(message) { }

    public ConcurrencyException(string? message, Exception? innerException) : base(message, innerException) { }
}
