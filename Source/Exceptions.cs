using System;

namespace NokLib
{
    /// <summary>
    /// Thrown when a collection limit is reached
    /// </summary>
    [Serializable]
    public class LimitReachedException : Exception
    {
        /// <summary>
        /// Create a new instance of the exception
        /// </summary>
        public LimitReachedException() { }
        /// <summary>
        /// Create a new instance of the exception with a message describing the cause of the exception
        /// </summary>
        /// <param name="message">Cause of the exception</param>
        public LimitReachedException(string message) : base(message) { }
    }

    /// <summary>
    /// Thrown when an object has an unexpected value, or type
    /// </summary>
    [Serializable]
    public class UnexpectedObjectException : Exception
    {
        /// <summary>
        /// Create a new instance of the exception
        /// </summary>
        public UnexpectedObjectException() { }
        /// <summary>
        /// Create a new instance of the exception with a message describing the cause of the exception
        /// </summary>
        /// <param name="message">Cause of the exception</param>
        public UnexpectedObjectException(string message) : base(message) { }
        /// <summary>
        /// Create a new instance of the exception with a message containing the object that caused the exception and its type
        /// </summary>
        /// <param name="unexpectedObject"></param>
        public UnexpectedObjectException(object unexpectedObject) : base($"Object {unexpectedObject} of type {unexpectedObject.GetType()} was not expected here") { }
    }

    /// <summary>
    /// Thrown when a type is not supported by a generic class/method
    /// </summary>
    [Serializable]
    public class UnsupportedTypeException : Exception
    {
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
        public UnsupportedTypeException(Type type) : base($"Objects of type {type.FullName} are not supported") { }
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
    }

    /// <summary>
    /// Thrown when an array has invalid size
    /// </summary>
    [Serializable]
    public class InvalidSizeException : Exception
    {
        /// <summary>
        /// Create a new instance of the exception
        /// </summary>
        public InvalidSizeException() { }
        /// <summary>
        /// Create a new instance of the exception with a message describing the cause of the exception
        /// </summary>
        /// <param name="message">Cause of the exception</param>
        public InvalidSizeException(string message) : base(message) { }
    }

    /// <summary>
    /// Thrown when a system is in a state where it cannot execute the called method
    /// </summary>
    [Serializable]
    public class InvalidStateException : Exception
    {
        /// <summary>
        /// Create a new instance of the exception
        /// </summary>
        public InvalidStateException() { }
        /// <summary>
        /// Create a new instance of the exception with a message describing the cause of the exception
        /// </summary>
        /// <param name="message">Cause of the exception</param>
        public InvalidStateException(string message) : base(message) { }
    }

    /// <summary>
    /// Thrown when a type is not a type the method requires
    /// </summary>
    [Serializable]
    public class TypeMismatchException : Exception
    {
        /// <summary>
        /// Create a new instance of the exception
        /// </summary>
        public TypeMismatchException() { }
        /// <summary>
        /// Create a new instance of the exception with a message describing the cause of the exception
        /// </summary>
        /// <param name="message">Cause of the exception</param>
        public TypeMismatchException(string message) : base(message) { }
        public TypeMismatchException(Type a, Type b, string reason) : base($"Type {a.Name} is {reason} {b.Name}") { }
    }

    /// <summary>
    /// Thrown when sizes of two array do not match
    /// </summary>
    [Serializable]
    public class SizeMismatchException : Exception
    {
        /// <summary>
        /// Create a new instance of the exception
        /// </summary>
        public SizeMismatchException() { }
        /// <summary>
        /// Create a new instance of the exception with a message describing the cause of the exception
        /// </summary>
        /// <param name="message">Cause of the exception</param>
        public SizeMismatchException(string message) : base(message) { }
        public SizeMismatchException(int sizeA, int sizeB) : base($"Object sizes do not match! {sizeA} != {sizeB}") { }
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
    }

    /// <summary>
    /// Thrown when an operation fails because of issues connected with concurrency
    /// </summary>
    [Serializable]
    public class ConcurrentException : Exception
    {
        /// <summary>
        /// Create a new instance of the exception
        /// </summary>
        public ConcurrentException() : base() { }
        /// <summary>
        /// Create a new instance of the exception with a message describing the cause of the exception
        /// </summary>
        /// <param name="message">Cause of the exception</param>
        public ConcurrentException(string message) : base(message) { }
    }
}
