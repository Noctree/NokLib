﻿using System;
using NokLib.Parsers;
using SysConsole = System.Console;

namespace NokLib.ConsoleUtils;

/// <summary>
/// Utility class for reading Console input
/// </summary>
public static class ConsoleReader
{
    private const string DEFAULT_ERROR_MESSAGE = "Invalid input!";

    public static int ReadInt(string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red) => ReadValue(FastIntParser.Instance, errorMessage, errorColor);
    public static uint ReadUInt(string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red) => ReadValue(FastUIntParser.Instance, errorMessage, errorColor);
    public static byte ReadByte(string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red) => ReadValue(FastByteParser.Instance, errorMessage, errorColor);
    public static sbyte ReadSByte(string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red) => ReadValue(FastSByteParser.Instance, errorMessage, errorColor);
    public static long ReadLong(string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red) => ReadValue(FastLongParser.Instance, errorMessage, errorColor);
    public static ulong ReadULong(string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red) => ReadValue(FastULongParser.Instance, errorMessage, errorColor);
    public static decimal ReadDecimal(string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red) => ReadValue(DecimalParser.Instance, errorMessage, errorColor);
    public static double ReadDouble(string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red) => ReadValue(DoubleParser.Instance, errorMessage, errorColor);
    public static float ReadFloat(string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red) => ReadValue(FloatParser.Instance, errorMessage, errorColor);
    public static T ReadValue<T>(IParser<T> parser, string errorMessage = DEFAULT_ERROR_MESSAGE, ConsoleColor errorColor = ConsoleColor.Red, bool allowEmpty = false, bool autoHideCursor = true) {
        string errorMsgErase = new string(' ', errorMessage.Length);
        T? result = default;
        int cursorLeft = SysConsole.CursorLeft;
        int cursorTop = SysConsole.CursorTop;
        SysConsole.CursorVisible = true;
        bool success = false;
        while (!success) {
            string input = SysConsole.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(input) && allowEmpty)
                break;
            success = parser.TryParse(input, out result);
            if (success)
                break;
            SysConsole.SetCursorPosition(cursorLeft, cursorTop);
            for (int i = 0; i < input.Length; ++i)
                SysConsole.Write(' ');
            SysConsole.SetCursorPosition(cursorLeft, cursorTop);
            ConsoleWriter.Write(errorMessage, errorColor);
            SysConsole.ReadKey(true);

            SysConsole.SetCursorPosition(cursorLeft, cursorTop);
            SysConsole.Write(errorMsgErase);
            SysConsole.SetCursorPosition(cursorLeft, cursorTop);
        }
        if (autoHideCursor)
            SysConsole.CursorVisible = false;
        return result!;
    }
}
