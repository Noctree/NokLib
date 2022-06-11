using System;
using BenchmarkDotNet.Attributes;
using NokLib;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class EnumStringifierBenchmark
    {
        private ConsoleColor[] colors = Enum.GetValues<ConsoleColor>();
        [GlobalSetup]
        private void Setup() {
            EnumStringifier.ToString(ConsoleColor.White);
        }

        [Benchmark]
        public void StandardToStringSingle() => ConsoleColor.White.ToString();
        [Benchmark]
        public void EnumStringifierToStringSingle() => EnumStringifier.ToString(ConsoleColor.White);
        [Benchmark]
        public void EnumStringifierExtensionToStringSingle() => ConsoleColor.White.ToStringNonAlloc();
        [Benchmark]
        public void StandardToStringAll() {
            foreach (var item in colors) {
                item.ToString();
            }
        }
        [Benchmark]
        public void EnumStringifierToString() {
            foreach (var item in colors) {
                EnumStringifier.ToString(item);
            }
        }
        [Benchmark]
        public void EnumStringifierExtensionToString() {
            foreach (var item in colors) {
                item.ToStringNonAlloc();
            }
        }
        [Benchmark]
        public void StandardGetNames() => Enum.GetNames(typeof(ConsoleColor));
        [Benchmark]
        public void EnumStringifierGetNames() => EnumStringifier.GetNames<ConsoleColor>();
    }
}
