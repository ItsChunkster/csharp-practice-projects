namespace TerminalCalculator;

public static class Memory
{
    private static double? StoredValue;

    public static void Store(double value)
    {
        StoredValue = value;
        ConsoleHelper.WriteSuccess($"  Stored {value} in memory.");
    }

    public static double? Recall()
    {
        if (StoredValue.HasValue)
        {
            ConsoleHelper.WriteInfo($"  Memory: {StoredValue.Value}");
            return StoredValue.Value;
        }

        ConsoleHelper.WriteWarning("  Memory is empty.");
        return null;
    }

    public static void Clear()
    {
        StoredValue = null;
        ConsoleHelper.WriteSuccess("  Memory cleared.");
    }

    public static bool HasValue => StoredValue.HasValue;

    public static double Value => StoredValue ?? 0;
}
