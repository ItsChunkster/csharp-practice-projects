namespace TerminalCalculator;

public static class InputHandler
{
    public static double ReadNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();

            CheckForExit(input);

            if (string.Equals(input, "mr", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(input, "recall", StringComparison.OrdinalIgnoreCase))
            {
                double? recalled = Memory.Recall();
                if (recalled.HasValue)
                    return recalled.Value;
                continue;
            }

            if (double.TryParse(input, out double number))
            {
                return number;
            }

            ConsoleHelper.WriteError("Invalid input. Please enter a valid number.");
        }
    }

    public static string ReadOperation(bool scientificMode)
    {
        string[] basicOps = ["+", "-", "*", "/", "^"];
        string[] scientificOps = ["sqrt", "sin", "cos", "tan", "log", "ln", "abs", "!"];
        string[] allOps = scientificMode ? [.. basicOps, .. scientificOps] : basicOps;

        Console.WriteLine();
        ConsoleHelper.WriteInfo("Select an operation:");
        Console.WriteLine("  1. Add (+)");
        Console.WriteLine("  2. Subtract (-)");
        Console.WriteLine("  3. Multiply (*)");
        Console.WriteLine("  4. Divide (/)");
        Console.WriteLine("  5. Power (^)");

        if (scientificMode)
        {
            Console.WriteLine("  6. Square Root (sqrt)");
            Console.WriteLine("  7. Sine (sin)");
            Console.WriteLine("  8. Cosine (cos)");
            Console.WriteLine("  9. Tangent (tan)");
            Console.WriteLine("  10. Log Base 10 (log)");
            Console.WriteLine("  11. Natural Log (ln)");
            Console.WriteLine("  12. Absolute Value (abs)");
            Console.WriteLine("  13. Factorial (!)");
        }

        Console.WriteLine();

        var choiceMap = new Dictionary<string, string>
        {
            ["1"] = "+", ["2"] = "-", ["3"] = "*", ["4"] = "/", ["5"] = "^",
            ["6"] = "sqrt", ["7"] = "sin", ["8"] = "cos", ["9"] = "tan",
            ["10"] = "log", ["11"] = "ln", ["12"] = "abs", ["13"] = "!"
        };

        int maxChoice = scientificMode ? 13 : 5;

        while (true)
        {
            Console.Write("Choice: ");
            string? input = Console.ReadLine()?.Trim().ToLower();

            CheckForExit(input);

            if (input != null && choiceMap.TryGetValue(input, out string? operation) && allOps.Contains(operation))
            {
                return operation;
            }

            if (input != null && allOps.Contains(input))
            {
                return input;
            }

            ConsoleHelper.WriteError($"Invalid choice. Please enter 1-{maxChoice}.");
        }
    }

    public static string ReadMenuChoice()
    {
        string[] validChoices = ["1", "2", "3", "4", "5", "6", "7", "8"];

        while (true)
        {
            Console.Write("Choice: ");
            string? input = Console.ReadLine()?.Trim();

            CheckForExit(input);

            if (input != null && validChoices.Contains(input))
            {
                return input;
            }

            ConsoleHelper.WriteError("Invalid choice. Please enter 1-8.");
        }
    }

    private static void CheckForExit(string? input)
    {
        if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
        {
            throw new ExitException();
        }
    }
}
