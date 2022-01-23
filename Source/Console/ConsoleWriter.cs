using System;
using System.Collections.Generic;
using System.Text;
using SysConsole = System.Console;

namespace NokLib.ConsoleUtils
{
    /// <summary>
    /// Utilities for writing into the console output
    /// </summary>
    public static class ConsoleWriter
    {
        public static void WriteLine() => SysConsole.WriteLine();
        public static void WriteLine<T>(T value) => SysConsole.WriteLine(value.ToString());
        public static void WriteLine<T>(T value, ConsoleColor foreground)
        {
            var color = SysConsole.ForegroundColor;
            SysConsole.ForegroundColor = foreground;

            SysConsole.WriteLine(value.ToString());

            SysConsole.ForegroundColor = color;
        }
        public static void WriteLine<T>(T value, ConsoleColor foreground, ConsoleColor background)
        {
            var foreColor = SysConsole.ForegroundColor;
            var backColor = SysConsole.BackgroundColor;
            SysConsole.ForegroundColor = foreground;
            SysConsole.BackgroundColor = background;

            SysConsole.WriteLine(value.ToString());

            SysConsole.ForegroundColor = foreColor;
            SysConsole.BackgroundColor = backColor;
        }
        public static void Write<T>(T value) => SysConsole.Write(value.ToString());
        public static void Write<T>(T value, ConsoleColor foreground)
        {
            var color = SysConsole.ForegroundColor;
            SysConsole.ForegroundColor = foreground;

            SysConsole.Write(value.ToString());

            SysConsole.ForegroundColor = color;
        }
        public static void Write<T>(T value, ConsoleColor foreground, ConsoleColor background)
        {
            var foreColor = SysConsole.ForegroundColor;
            var backColor = SysConsole.BackgroundColor;
            SysConsole.ForegroundColor = foreground;
            SysConsole.BackgroundColor = background;

            SysConsole.Write(value.ToString());

            SysConsole.ForegroundColor = foreColor;
            SysConsole.BackgroundColor = backColor;
        }
    }
}
