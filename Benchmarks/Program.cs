using System;
using System.Diagnostics;
using BenchmarkDotNet;
using NokLib;

namespace Benchmarks
{
    internal static class Program
    {
        private static void Main() {
            //Console.Write("Input number: ");
            //Console.WriteLine("Received input: " + ConsoleReader.ReadInt());
            //Console.ReadKey();
            BenchmarkDotNet.Running.BenchmarkRunner.Run<EnumStringifierBenchmark>();
            //SimpleBenchmark("EnumToStringStandard", () => ConsoleColor.White.ToString());
            //SimpleBenchmark("EnumToString", () => ConsoleColor.White.ToStringNonAlloc());
            Console.ReadKey();
        }

        private static void SimpleBenchmark(string name, Action action) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 1_000_000; i++)
                action();
            stopwatch.Stop();
            Console.WriteLine($"Benchmark {name} took {stopwatch.Elapsed}");
        }
    }
}
