namespace TerminalCalculator;

public static class Memory
{
    private static double? _storedValue;

    public static void Store(double value)
    {
        _storedValue = value;
        ConsoleHelper.WriteSuccess($"  Stored {value} in memory.");
    }

    public static double? Recall()
    {
        if (_storedValue.HasValue)
        {
            ConsoleHelper.WriteInfo($"  Memory: {_storedValue.Value}");
            return _storedValue.Value;
        }

        ConsoleHelper.WriteWarning("  Memory is empty.");
        return null;
    }

    public static void Clear()
    {
        _storedValue = null;
        ConsoleHelper.WriteSuccess("  Memory cleared.");
    }

}
