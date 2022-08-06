using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using NokLib;

namespace Benchmarks;

public class ScannerBenchmark
{
    private MemoryStream stream;
    private StreamScanner scanner;

    [GlobalSetup]
    public void GlobalSetup() {
        stream = new MemoryStream();
        scanner = new StreamScanner(stream);

        Random rng = new Random(123);
        for (int i = 0; i < 10000; i++) {
            double number = rng.NextDouble();
            stream.Write(number.ToString().ToAsciiByteArray());
            stream.Write("\n".ToAsciiByteArray());
        }
        stream.Position = 0;
    }

    [GlobalCleanup]
    public void GlobalCleanup() {
        scanner.Dispose();
        stream.Dispose();
    }

    [Benchmark]
    public void ReadDouble() {
        scanner.ReadDouble();
        stream.ReadByte();
    }
}
