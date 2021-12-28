using System;
using System.Collections.Generic;
using System.Text;

namespace NokLib
{
    /// <summary>
    /// Enables use of the 
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A>
    {
        public void Deconstruct(out A a);
    }

    /// <summary>
    /// Enables use of the 
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B>
    {
        public void Deconstruct(out A a, out B b);
    }

    /// <summary>
    /// Enables use of the 
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C>
    {
        public void Deconstruct(out A a, out B b, out C c);
    }

    /// <summary>
    /// Enables use of the 
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C, D>
    {
        public void Deconstruct(out A a, out B b, out C c, out D d);
    }

    /// <summary>
    /// Enables use of the 
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C, D, E>
    {
        public void Deconstruct(out A a, out B b, out C c, out D d, out E e);
    }

    /// <summary>
    /// Enables use of the 
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C, D, E, F>
    {
        public void Deconstruct(out A a, out B b, out C c, out D d, out E e, out F f);
    }

    /// <summary>
    /// Enables use of the 
    /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct">tuple deconstruction syntax</see>
    /// </summary>
    public interface IDeconstructible<A, B, C, D, E, F, G>
    {
        public void Deconstruct(out A a, out B b, out C c, out D d, out E e, out F f, out G g);
    }
}
