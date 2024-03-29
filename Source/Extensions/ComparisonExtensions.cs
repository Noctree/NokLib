﻿using System;
using System.Collections.Generic;

namespace NokLib;

public static class ComparisonExtensions
{
    public static bool AreEqual<T>(this IComparer<T> comparer, T x, T y) => comparer.Compare(x, y) == 0;
    public static bool AreEqual<T>(this IComparable<T> comparable, T b) => comparable.CompareTo(b) == 0;
    public static bool AreEqual(this IComparable comparable, object? b) => comparable.CompareTo(b) == 0;
}
