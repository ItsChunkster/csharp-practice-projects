namespace TerminalCalculator;

public static class History
{
    private static readonly List<string> Entries = [];

    public static void Add(string entry)
    {
        Entries.Add(entry);
    }

    public static void Show()
    {
        Console.WriteLine();
        if (Entries.Count == 0)
        {
            ConsoleHelper.WriteWarning("  No calculations yet.");
        }
        else
        {
            ConsoleHelper.WriteInfo("  Calculation History:");
            ConsoleHelper.WriteInfo("  --------------------");
            for (int i = 0; i < Entries.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {Entries[i]}");
            }
        }
        Console.WriteLine();
    }

    public static void Clear()
    {
        Entries.Clear();
        ConsoleHelper.WriteSuccess("  History cleared.");
        Console.WriteLine();
    }
}
