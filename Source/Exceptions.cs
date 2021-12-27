using System;

namespace NokLib
{
    [Serializable]
    public class LimitReachedException : Exception
    {
        public LimitReachedException() { }
        public LimitReachedException(string message) : base(message) { }
    }

    [Serializable]
    public class UnexpectedObjectException : Exception
    {
        public UnexpectedObjectException() { }
        public UnexpectedObjectException(string message) : base(message) { }
        public UnexpectedObjectException(object unexpectedObject) : base($"Object {unexpectedObject} of type {unexpectedObject.GetType()} was not expected here") { }
    }

    [Serializable]
    public class UnsupportedOperationException : Exception
    {
        public UnsupportedOperationException() { }
        public UnsupportedOperationException(string message) : base(message) { }
    }

    [Serializable]
    public class InvalidHandleException : Exception
    {
        public InvalidHandleException() { }
        public InvalidHandleException(string message) : base(message) { }
    }

    [Serializable]
    public class InvalidSizeException : Exception
    {
        public InvalidSizeException() { }
        public InvalidSizeException(string message) : base(message) { }
    }

    [Serializable]
    public class InvalidStateException : Exception
    {
        public InvalidStateException() { }
        public InvalidStateException(string message) : base(message) { }
    }

    [Serializable]
    public class TypeMismatchException : Exception
    {
        public TypeMismatchException() { }
        public TypeMismatchException(string message) : base(message) { }
        public TypeMismatchException(Type a, Type b, string reason) : base($"Type {a.Name} is {reason} {b.Name}") { }
    }

    [Serializable]
    public class SizeMismatchException : Exception
    {
        public SizeMismatchException() { }
        public SizeMismatchException(string message) : base(message) { }
        public SizeMismatchException(int sizeA, int sizeB) : base($"Object sizes do not match! {sizeA} != {sizeB}") { }
    }

    [Serializable]
    public class DuplicateObjectInCollectionException : Exception
    {
        public DuplicateObjectInCollectionException() : base("This object is already contained in this collection") { }
        public DuplicateObjectInCollectionException(string message) : base(message) { }
    }

    [Serializable]
    public class ConcurrentException : Exception
    {
        public ConcurrentException() : base() { }
        public ConcurrentException(string message) : base(message) { }
    }
}
