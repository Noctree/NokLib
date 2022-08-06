using System;
using BenchmarkDotNet.Attributes;
using NokLib;

namespace Benchmarks;

public class UnsafeConversionBenchmark
{
    [Params(true, false)]
    public bool Boolean { get; set; }

    [Params(ConsoleColor.White)]
    public ConsoleColor Enum { get; set; }

    [Benchmark]
    public int BooleanAsInt() => Boolean.ToInt();

    [Benchmark]
    public int BooleanAsIntFast() => Boolean.ToIntFast();

    [Benchmark]
    public int EnumAsInt() => Enum.ToInt();
    [Benchmark]
    public int EnumAsIntFast() => Enum.ToIntFast();
}
