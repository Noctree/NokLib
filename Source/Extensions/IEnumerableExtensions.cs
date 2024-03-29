﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NokLib;

public static class IEnumerableExtensions
{
    /// <summary>
    /// Calls Dispose for each item from the enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    public static void DisposeObjects<T>(this IEnumerable<T> collection) where T : IDisposable {
        foreach (var item in collection)
            item.Dispose();
    }

    /// <summary>
    /// For each enumerated item calls the disposeFunction with the item as an argument
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="disposeFunction"></param>
    public static void DisposeObjectsWith<T>(this IEnumerable<T> collection, Action<T> disposeFunction) {
        foreach (var item in collection)
            disposeFunction(item);
    }

    /// <summary>
    /// Finds both the minimum and maximum of the collection in one pass
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    public static ValueTuple<T, T> MinMax<T>(this IEnumerable<T> collection) where T : notnull, IComparable<T> {
        if (collection.FirstOrDefault() is null)
            return default;
        T min, max;
        min = max = collection.First();
        foreach (var item in collection) {
            if (item.CompareTo(min) < 0)
                min = item;
            else if (item.CompareTo(max) > 0)
                max = item;
        }
        return new ValueTuple<T, T>(min, max);
    }

    /// <summary>
    /// Finds both the minimum and maximum of the collection in one pass using the supplied compareFunction
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="compareFunction">Comparer function for the items in the collection, should follow the IComparable method (negative result = less, 0 = equal, positive result = greater)</param>
    public static ValueTuple<T, T> MinMax<T>(this IEnumerable<T> collection, Func<T, T, int> compareFunction) {
        if (collection.FirstOrDefault() is null)
            return default;
        T min, max;
        min = max = collection.First();
        foreach (var item in collection) {
            if (compareFunction(item, min) < 0)
                min = item;
            else if (compareFunction(item, max) > 0)
                max = item;
        }
        return new ValueTuple<T, T>(min, max);
    }

    ///<inheritdoc cref="FormatToString{T}(IEnumerable{T}, Func{T, string})"/>
    public static string FormatToString<T>(this IEnumerable<T> collection) => Internal_FormatToStringGeneric(collection, MiscellaneousExtensions.SafeToString);

    /// <summary>
    /// Formats the output of the enumerable into a string
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="customFormatter">Function for converting the object into string</param>
    public static string FormatToString<T>(this IEnumerable<T> collection, Func<T, string> customFormatter) => Internal_FormatToStringGeneric(collection, customFormatter);

    public static string Internal_FormatToStringGeneric<T>(IEnumerable<T> collection, Func<T, string> customFormatter) {
        const string separator = ", ";
        var sb = StringBuilderPool.Get();
        sb.Append('(');
        foreach (var item in collection) {
            sb.Append(customFormatter(item));
            sb.Append(separator);
        }
        sb.Remove(sb.Length - 2, 2);
        sb.Append(')');
        string result = sb.ToString();
        StringBuilderPool.Release(sb);
        return result;
    }

    /// <inheritdoc cref="FormatToString(IEnumerable, Func{object, string})"/>
    public static string FormatToString(this IEnumerable collection) => Internal_FormatToString(collection, MiscellaneousExtensions.SafeToString);

    /// <summary>
    /// Formats the output of the enumerable into a string
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="customFormatter">Function for converting the objects into string</param>
    public static string FormatToString(this IEnumerable collection, Func<object, string> customFormatter) => Internal_FormatToString(collection, customFormatter);

    private static string Internal_FormatToString(IEnumerable collection, Func<object, string> customFormatter) {
        const string separator = ", ";
        var sb = StringBuilderPool.Get();
        sb.Append('(');
        foreach (var item in collection) {
            sb.Append(customFormatter(item));
            sb.Append(separator);
        }
        sb.Remove(sb.Length - 2, 2);
        sb.Append(')');
        string result = sb.ToString();
        StringBuilderPool.Release(sb);
        return result;
    }

    /// <summary>
    /// Performs the specified action on all elements of the enumerable. DOES NOT MODIFY THE ENUMERABLE.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="action"></param>
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
        foreach (T obj in collection)
            action(obj);
        return collection;
    }
}
