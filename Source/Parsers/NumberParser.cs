using System;

namespace NokLib.Parsers;

internal static class NumberParser
{
    internal static bool TryParseNumber(ReadOnlySpan<char> input, ulong maxValue, out ulong result) {
        result = 0;
        if (input.IsEmpty || input.Length == 0)
            return false;

        ulong preResult = 0;
        for (int i = 0; i < input.Length; ++i) {
            char symbol = input[i];
            if (!char.IsDigit(symbol))
                return false;
            preResult *= 10;
            preResult += (ulong)symbol - '0';
            if (preResult < result || preResult > maxValue)
                return false;
            result = preResult;
        }
        return true;
    }

    internal static bool TryParseNumberOld(ReadOnlySpan<char> input, ulong maxValue, out ulong result) {
        result = 0;
        if (input.IsEmpty || input.Length == 0)
            return false;

        ulong maxNumberLastDigit = maxValue % 10;
        ulong maxNumberRounded = maxValue - maxNumberLastDigit;
        for (int i = 0; i < input.Length; ++i) {
            char symbol = input[i];
            result *= 10;
            if (result == maxNumberRounded) {
                return TryParseLastDigit(symbol, maxNumberLastDigit, ref result) && i == input.Length - 1;
            }
            result += (ulong)symbol - '0';
        }
        return true;
    }

    private static bool TryParseLastDigit(char input, ulong maxLastDigit, ref ulong result) {
        ulong lastDigit = (ulong)input - '0';
        if (lastDigit > maxLastDigit)
            return false;
        result += lastDigit;
        return true;
    }

    internal static bool TryParseUInt(ReadOnlySpan<char> input, out uint result) {
        result = 0;
        if (input.IsEmpty || input.Length == 0)
            return false;

        uint preResult = 0;
        for (int i = 0; i < input.Length; ++i) {
            char symbol = input[i];
            preResult *= 10;
            preResult += (uint)symbol - '0';
            if (preResult < result)
                return false;
            result = preResult;
        }
        return true;
    }
}
