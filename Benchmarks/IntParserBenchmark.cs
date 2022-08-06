using BenchmarkDotNet.Attributes;
using NokLib.Parsers;

namespace Benchmarks;

[MemoryDiagnoser]
public class IntParserBenchmark
{
    public static readonly string IntMaxValue = int.MaxValue.ToString();
    public static readonly string IntMinValue = int.MinValue.ToString();
    [Benchmark]
    public void IntParseStandard() => int.TryParse(IntMaxValue, out int result);
    [Benchmark]
    public void IntParse() => FastIntParser.TryParseS(IntMaxValue, out int result);
    [Benchmark]
    public void IntParseStandardMin() => int.TryParse(IntMinValue, out int result);
    [Benchmark]
    public void IntParseMin() => FastIntParser.TryParseS(IntMinValue, out int result);
}
