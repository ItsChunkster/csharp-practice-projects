namespace TerminalCalculator;

public static class ConsoleHelper
{
    public static void WriteColored(string text, ConsoleColor color)
    {
        ConsoleColor original = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = original;
    }

    public static void WriteLineColored(string text, ConsoleColor color)
    {
        WriteColored(text + Environment.NewLine, color);
    }

    public static void WriteSuccess(string text)
    {
        WriteLineColored(text, ConsoleColor.Green);
    }

    public static void WriteError(string text)
    {
        WriteLineColored(text, ConsoleColor.Red);
    }

    public static void WriteInfo(string text)
    {
        WriteLineColored(text, ConsoleColor.Cyan);
    }

    public static void WriteWarning(string text)
    {
        WriteLineColored(text, ConsoleColor.Yellow);
    }

    public static void WriteHeader(string text)
    {
        WriteLineColored(text, ConsoleColor.Magenta);
    }

    public static void WriteResult(string text)
    {
        WriteLineColored(text, ConsoleColor.White);
    }
}
