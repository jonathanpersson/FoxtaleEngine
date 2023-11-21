using System;
using System.Diagnostics.CodeAnalysis;

namespace Foxtale.Core;

public enum LogLevel
{
    Information = 0,
    Warning = 1,
    Error = 2,
    Build = 3,
}

public static class Logger
{
    public static void Log(LogLevel level, string text)
    {
        string levelLabel;
        ConsoleColor color = ConsoleColor.Gray;

        switch (level)
        {
            case LogLevel.Information:
                levelLabel = "INFO";
                color = ConsoleColor.Blue;
                break;
            case LogLevel.Warning:
                levelLabel = "WARNING";
                color = ConsoleColor.Yellow;
                break;
            case LogLevel.Error:
                levelLabel = "ERROR";
                color = ConsoleColor.Red;
                break;
            case LogLevel.Build:
                levelLabel = "BUILD";
                color = ConsoleColor.Green;
                break;
            default:
                levelLabel = "LOG";
                break;
        }

        Console.Write("[");
        Console.ForegroundColor = color;
        Console.Write(levelLabel);
        Console.ResetColor();
        Console.Write("] ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
