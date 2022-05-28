namespace NokLib
{
    /// <summary>
    /// Enables use of the
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A>
    {
        /// <summary>
        /// Deconstructs the object
        /// </summary>
        public void Deconstruct(out A a);
    }

    /// <summary>
    /// Enables use of the
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B>
    {
        /// <summary>
        /// Deconstructs the object
        /// </summary>
        public void Deconstruct(out A a, out B b);
    }

    /// <summary>
    /// Enables use of the
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C>
    {
        /// <summary>
        /// Deconstructs the object
        /// </summary>
        public void Deconstruct(out A a, out B b, out C c);
    }

    /// <summary>
    /// Enables use of the
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C, D>
    {
        /// <summary>
        /// Deconstructs the object
        /// </summary>
        public void Deconstruct(out A a, out B b, out C c, out D d);
    }

    /// <summary>
    /// Enables use of the
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C, D, E>
    {
        /// <summary>
        /// Deconstructs the object
        /// </summary>
        public void Deconstruct(out A a, out B b, out C c, out D d, out E e);
    }

    /// <summary>
    /// Enables use of the
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C, D, E, F>
    {
        /// <summary>
        /// Deconstructs the object
        /// </summary>
        public void Deconstruct(out A a, out B b, out C c, out D d, out E e, out F f);
    }

    /// <summary>
    /// Enables use of the
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C, D, E, F, G>
    {
        /// <summary>
        /// Deconstructs the object
        /// </summary>
        public void Deconstruct(out A a, out B b, out C c, out D d, out E e, out F f, out G g);
    }
}
