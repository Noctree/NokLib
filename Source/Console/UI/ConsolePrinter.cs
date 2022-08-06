using System;
using System.Text;
using System.Threading;
using SysConsole = System.Console;

namespace NokLib.ConsoleUtils.UI;

public static class ConsolePrinter
{
    private static string lineCleaner = String.Empty;

    private static void UpdateLineCleaner() {
        if (lineCleaner.Length != SysConsole.WindowWidth - 1)
            lineCleaner = new string(' ', SysConsole.WindowWidth - 1);
    }
    public static void PrintSeparator(string separator = "=", ConsoleColor foreground = ConsoleColor.White) {
        StringBuilder sb = StringBuilderPool.Get();
        int size = SysConsole.BufferWidth / separator.Length;
        for (int i = 0; i < size; i++) {
            sb.Append(separator);
        }
        ConsoleWriter.WriteLine(sb.ToString(), foreground);
    }

    public static void PrintRight(string str, ConsoleColor foreground = ConsoleColor.White, bool newLine = true) {
        SysConsole.CursorLeft = SysConsole.WindowWidth - 1 - str.Length;
        if (newLine)
            ConsoleWriter.WriteLine(str, foreground);
        else
            ConsoleWriter.Write(str, foreground);
    }

    public static void PrintRightDelayed(string text, int delay = 32, ConsoleColor foreground = ConsoleColor.White, bool newLine = false, bool skippable = true) {
        bool first = true;
        foreach (string part in text.Split('\n')) {
            if (!first)
                SysConsole.WriteLine();
            for (int i = 0; i <= part.Length; i++) {
                PrintRight(part.Substring(0, i), foreground, false);
                Thread.Sleep(delay);
                if (SysConsole.KeyAvailable && skippable) {
                    SysConsole.ReadKey(true);
                    PrintRight(part, foreground, false);
                    break;
                }
            }
            first = false;
        }
        if (newLine)
            SysConsole.WriteLine();
    }

    public static int PrintCentered(string str, ConsoleColor foreground = ConsoleColor.White, bool newLine = true) {
        SysConsole.CursorLeft = (SysConsole.BufferWidth - str.Length) / 2;
        if (newLine)
            ConsoleWriter.WriteLine(str, foreground);
        else
            ConsoleWriter.Write(str, foreground);
        return SysConsole.CursorLeft;
    }

    public static int PrintCenteredDelayed(string text, int delay = 32, ConsoleColor foreground = ConsoleColor.White, bool skippable = true, bool newLine = true) {
        int cursorPos = SysConsole.CursorLeft;
        bool first = true;
        foreach (string part in text.Split('\n')) {
            if (!first)
                SysConsole.WriteLine();
            for (int i = 0; i <= part.Length; i++) {
                cursorPos = PrintCentered(part.Substring(0, i), foreground, false);
                Thread.Sleep(delay);
                SysConsole.CursorLeft = 0;
                if (SysConsole.KeyAvailable && skippable) {
                    SysConsole.ReadKey(true);
                    cursorPos = PrintCentered(part, foreground, false);
                    break;
                }
            }
            first = false;
        }
        if (newLine)
            SysConsole.WriteLine();
        return cursorPos;
    }

    public static void ClearArea(int startX, int startY, int endX = -1, int endY = -1) {
        if (endX < 0)
            endX = SysConsole.BufferWidth;
        if (endY < 0)
            endY = SysConsole.BufferHeight;

        if (startX > endX || startX > SysConsole.BufferWidth)
            throw new ArgumentOutOfRangeException(nameof(startX));
        if (startY > endY || startY > SysConsole.BufferHeight)
            throw new ArgumentOutOfRangeException(nameof(startY));
        if (endX > SysConsole.BufferWidth)
            throw new ArgumentOutOfRangeException(nameof(endX));
        if (endY > SysConsole.BufferHeight)
            throw new ArgumentOutOfRangeException(nameof(endY));

        if (endX - startX == SysConsole.BufferWidth) {
            ClearRows(startY, endY);
            return;
        }

        int left = SysConsole.CursorLeft;
        int top = SysConsole.CursorTop;
        SysConsole.SetCursorPosition(startX, startY);
        string line = new string(' ', endX - startX);
        for (int y = startY; y < endY - 1; y++) {
            SysConsole.Write(line);
            SysConsole.CursorTop += 1;
            SysConsole.CursorLeft = startX;
        }
        SysConsole.Write(line);
        SysConsole.CursorTop = 0;
        SysConsole.SetCursorPosition(left, top);
    }

    public static void ClearRows(int startY, int endY = -1) {
        if (startY < 0 || startY > SysConsole.BufferHeight)
            throw new ArgumentOutOfRangeException(nameof(startY));
        if (endY < 0)
            endY = SysConsole.BufferHeight;

        if (endY < startY)
            throw new ArgumentOutOfRangeException(nameof(endY));

        UpdateLineCleaner();

        int top = SysConsole.CursorTop;
        int left = SysConsole.CursorLeft;
        SysConsole.SetCursorPosition(0, startY);
        for (int i = startY; i < endY - 1; i++) {
            SysConsole.Write(lineCleaner);
            SysConsole.CursorTop += 1;
            SysConsole.CursorLeft = 0;
        }
        SysConsole.Write(lineCleaner);

        SysConsole.CursorTop = 0;
        SysConsole.SetCursorPosition(left, top);
    }

    public static void PrintTextDelayed(string text, ConsoleColor foreground = ConsoleColor.White, int delay = 32, bool newLine = false, bool skippable = true) {
        var foregroundBackup = SysConsole.ForegroundColor;
        SysConsole.ForegroundColor = foreground;
        for (int i = 0; i < text.Length; i++) {
            SysConsole.Write(text[i]);
            Thread.Sleep(delay);
            if (SysConsole.KeyAvailable && skippable) {
                SysConsole.ReadKey(true);
                ConsoleWriter.Write(text.Substring(i), foreground);
                break;
            }
        }
        if (newLine)
            SysConsole.WriteLine();
        SysConsole.ForegroundColor = foregroundBackup;
    }

    public static void PrintText(string text, ConsoleColor foreground = ConsoleColor.White) => ConsoleWriter.Write(text, foreground);

    public static void ClearConsoleInput() {
        while (SysConsole.KeyAvailable)
            SysConsole.ReadKey(true);
    }
}
