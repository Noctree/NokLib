using System;
using System.Collections.Generic;
#if UNITY_NOKLIB
using UnityEngine;
#endif

namespace NokLib;

public interface IRange<T> : IDeconstructible<T, T>
{
    public T Min { get; set; }
    public T Max { get; set; }
    public void Swap();
}

public interface IComparableRange<T> : IRange<T>, IEquatable<IComparableRange<T>>
{
    public bool InRange(T value);
    public bool InRangeInclusive(T value);
    public bool InRangeExclusive(T value);
}

[Serializable]
public struct Range<T> : IRange<T>
{
#if UNITY_NOKLIB
    [SerializeField]
#endif
    private T min;

#if UNITY_NOKLIB
    [SerializeField]
#endif
    private T max;

    public T Min { get => min; set => min = value; }
    public T Max { get => max; set => max = value; }

    public Range(T Min, T Max) {
        min = Min;
        max = Max;
    }

    public Range(IRange<T> range) {
        min = range.Min;
        max = range.Max;
    }

    public void Swap() => (Max, Min) = (Min, Max);

    public T Interpolate(Func<T, T, float, T> interpolationFunc, float time) => interpolationFunc(Min, Max, time);

    public override bool Equals(object? obj) {
        return obj is Range<T> range &&
               EqualityComparer<T>.Default.Equals(Min, range.Min) &&
               EqualityComparer<T>.Default.Equals(Max, range.Max);
    }

    public override int GetHashCode() => HashCode.Combine(Min, Max);

    public void Deconstruct(out T a, out T b) {
        a = Min;
        b = Max;
    }

    public static bool operator ==(Range<T> left, Range<T> right) => left.Equals(right);

    public static bool operator !=(Range<T> left, Range<T> right) => !(left == right);
}

[Serializable]
public struct ComparableRange<T> : IComparableRange<T> where T : IComparable
{
#if UNITY_NOKLIB
    [SerializeField]
#endif
    private T min;

#if UNITY_NOKLIB
    [SerializeField]
#endif
    private T max;

    public T Min { get => min; set => min = value; }
    public T Max { get => max; set => max = value; }

    public ComparableRange(T Min, T Max) {
        this.min = Min;
        this.max = Max;
    }

    public void Swap() => (Max, Min) = (Min, Max);

    public bool InRange(T value) => value.CompareTo(Min) >= 0 && value.CompareTo(Max) < 0;

    public bool InRangeInclusive(T value) => value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;

    public bool InRangeExclusive(T value) => value.CompareTo(Min) > 0 && value.CompareTo(Max) < 0;

    public T Interpolate(Func<T, T, float, T> interpolationFunc, float time) => interpolationFunc(Min, Max, time);

    public override bool Equals(object? obj) {
        return obj is ComparableRange<T> range &&
               EqualityComparer<T>.Default.Equals(Min, range.Min) &&
               EqualityComparer<T>.Default.Equals(Max, range.Max);
    }
    public bool Equals(IComparableRange<T>? other) => other is not null && this.Min.CompareTo(other.Min) == 0 && this.Max.CompareTo(other.Max) == 0;

    public override int GetHashCode() => HashCode.Combine(Min, Max);

    public void Deconstruct(out T a, out T b) {
        a = Min;
        b = Max;
    }

    public static implicit operator Range<T>(ComparableRange<T> compRange) => new Range<T>(compRange);

    public static bool operator ==(ComparableRange<T> left, ComparableRange<T> right) => left.Equals(right);

    public static bool operator !=(ComparableRange<T> left, ComparableRange<T> right) => !(left == right);
}

[Serializable]
public struct IntRange : IComparableRange<int>
{
#if UNITY_NOKLIB
    [SerializeField]
#endif
    private int min;

#if UNITY_NOKLIB
    [SerializeField]
#endif
    private int max;

    public static IntRange ZeroHundred => new IntRange(0, 100);
    public int Min { get => min; set => min = value; }
    public int Max { get => max; set => max = value; }

    public IntRange(int min, int max) {
        this.min = min;
        this.max = max;
    }

#if UNITY_NOKLIB
    public IntRange(Vector2 vector)
    {
        this.min = Mathf.RoundToInt(vector.x);
        this.max = Mathf.RoundToInt(vector.y);
    }

    public IntRange(Vector2Int vector)
    {
        this.min = vector.x;
        this.max = vector.y;
    }
#endif

    public IntRange(IRange<int> range) {
        this.min = range.Min;
        this.max = range.Max;
    }

    public void Swap() => (Max, Min) = (Min, Max);

    public bool InRange(int value) => value >= Min && value < Max;

    public bool InRangeInclusive(int value) => value >= Min && value <= Max;

    public bool InRangeExclusive(int value) => value > Min && value < Max;

    public int Lerp(float time) => Interpolation.Linear(Min, Max, time);

    public int Interpolate(Func<int, int, float, int> interpolationFunc, float time) => interpolationFunc(Min, Max, time);

    public override bool Equals(object? obj) {
        return obj is IntRange range &&
               Min == range.Min &&
               Max == range.Max;
    }

    public bool Equals(IComparableRange<int>? other) => other is not null && this.Min == other.Min && this.Max == other.Max;

    public override int GetHashCode() => HashCode.Combine(Min, Max);

    public void Deconstruct(out int a, out int b) {
        a = Min;
        b = Max;
    }

#if UNITY_NOKLIB
    public static implicit operator Vector2(IntRange range)
    {
        return new Vector2(range.Min, range.Max);
    }

    public static implicit operator Vector2Int(IntRange range)
    {
        return new Vector2Int(range.Min, range.Max);
    }

    public static implicit operator IntRange(Vector2 vector)
    {
        return new IntRange(vector);
    }

    public static implicit operator IntRange(Vector2Int vector)
    {
        return new IntRange(vector);
    }
#endif

    public static implicit operator Range<int>(IntRange range) => new Range<int>(range);

    public static bool operator ==(IntRange left, IntRange right) => left.Equals(right);

    public static bool operator !=(IntRange left, IntRange right) => !(left == right);
}

[Serializable]
public struct FloatRange : IComparableRange<float>
{
#if UNITY_NOKLIB
    [SerializeField]
#endif
    private float min;

#if UNITY_NOKLIB
    [SerializeField]
#endif
    private float max;

    public static FloatRange ZeroOne => new FloatRange(0, 1);
    public float Min { get => min; set => min = value; }
    public float Max { get => max; set => max = value; }

    public FloatRange(float min, float max) {
        this.min = min;
        this.max = max;
    }

#if UNITY_NOKLIB
    public FloatRange(Vector2 vector)
    {
        this.min = vector.x;
        this.max = vector.y;
    }

    public FloatRange(Vector2Int vector)
    {
        this.min = vector.x;
        this.max = vector.y;
    }
#endif

    public FloatRange(IRange<float> range) {
        this.min = range.Min;
        this.max = range.Max;
    }

    public void Swap() => (Max, Min) = (Min, Max);

    public bool InRange(float value) => value >= Min && value < Max;

    public bool InRangeInclusive(float value) => value >= Min && value <= Max;

    public bool InRangeExclusive(float value) => value > Min && value < Max;

    public float Lerp(float time) => Interpolation.Linear(Min, Max, time).ToFloat();

    public float Interpolate(Func<float, float, float, float> interpolationFunc, float time) => interpolationFunc(Min, Max, time);

    public override bool Equals(object? obj) {
        return obj is FloatRange range &&
               Min == range.Min &&
               Max == range.Max;
    }

    public bool Equals(IComparableRange<float>? range) => range is not null && Min.AlmostEquals(range.Min) && Max.AlmostEquals(range.Max);

    public override int GetHashCode() => HashCode.Combine(Min, Max);

    public void Deconstruct(out float a, out float b) {
        a = Min;
        b = Max;
    }

#if UNITY_NOKLIB
    public static implicit operator Vector2(FloatRange range)
    {
        return new Vector2(range.Min, range.Max);
    }

    public static implicit operator Vector2Int(FloatRange range)
    {
        return new Vector2Int(Mathf.RoundToInt(range.Min), Mathf.RoundToInt(range.Max));
    }

    public static implicit operator FloatRange(Vector2 vector)
    {
        return new FloatRange(vector);
    }

    public static implicit operator FloatRange(Vector2Int vector)
    {
        return new FloatRange(vector);
    }
#endif

    public static implicit operator Range<float>(FloatRange range) => new Range<float>(range);

    public static bool operator ==(FloatRange left, FloatRange right) => left.Equals(right);

    public static bool operator !=(FloatRange left, FloatRange right) => !(left == right);
}
