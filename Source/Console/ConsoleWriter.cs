using System;
using SysConsole = System.Console;

namespace NokLib.ConsoleUtils
{
    /// <summary>
    /// Utilities for writing into the console output
    /// </summary>
    public static class ConsoleWriter
    {
        public static void WriteLine() => SysConsole.WriteLine();
        public static void WriteLine<T>(T value) => SysConsole.WriteLine(value.SafeToString());
        public static void WriteLine<T>(T value, ConsoleColor foreground) {
            var color = SysConsole.ForegroundColor;
            SysConsole.ForegroundColor = foreground;

            WriteLine(value);

            SysConsole.ForegroundColor = color;
        }
        public static void WriteLine<T>(T value, ConsoleColor foreground, ConsoleColor background) {
            var foreColor = SysConsole.ForegroundColor;
            var backColor = SysConsole.BackgroundColor;
            SysConsole.ForegroundColor = foreground;
            SysConsole.BackgroundColor = background;

            WriteLine(value);

            SysConsole.ForegroundColor = foreColor;
            SysConsole.BackgroundColor = backColor;
        }
        public static void Write<T>(T value) => SysConsole.Write(value.SafeToString());
        public static void Write<T>(T value, ConsoleColor foreground) {
            var color = SysConsole.ForegroundColor;
            SysConsole.ForegroundColor = foreground;

            Write(value);

            SysConsole.ForegroundColor = color;
        }
        public static void Write<T>(T value, ConsoleColor foreground, ConsoleColor background) {
            var foreColor = SysConsole.ForegroundColor;
            var backColor = SysConsole.BackgroundColor;
            SysConsole.ForegroundColor = foreground;
            SysConsole.BackgroundColor = background;

            Write(value);

            SysConsole.ForegroundColor = foreColor;
            SysConsole.BackgroundColor = backColor;
        }
    }
}
