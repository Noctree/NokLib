﻿using System;

namespace NokLib.Parsers;

public class FastULongParser : IParser<ulong>
{
    public static readonly FastULongParser Instance = new FastULongParser();

    public ulong Parse(string input) => TryParse(input, out var result) ? result : throw new FormatException();
    public bool TryParse(string input, out ulong result) => NumberParser.TryParseNumber(input.AsSpan(), ulong.MaxValue, out result);

    public static bool TryParseS(string input, out ulong result) => Instance.TryParse(input, out result);
}
