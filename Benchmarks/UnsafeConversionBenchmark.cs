using System;
using BenchmarkDotNet.Attributes;
using NokLib;

namespace Benchmarks
{
    public class UnsafeConversionBenchmark
    {
        [Params(true, false)]
        public bool Boolean { get; set; }

        [Params(ConsoleColor.White)]
        public ConsoleColor Enum { get; set; }

        [Benchmark]
        public int BooleanAsInt() => Boolean.AsInt();

        [Benchmark]
        public int BooleanAsIntFast() => Boolean.AsIntFast();

        [Benchmark]
        public int EnumAsInt() => Enum.AsInt();
        [Benchmark]
        public int EnumAsIntFast() => Enum.AsIntFast();
    }
}
