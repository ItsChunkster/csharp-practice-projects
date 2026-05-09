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

        while (true)
        {
            if (scientificMode)
                Console.Write("Operation (+, -, *, /, ^, sqrt, sin, cos, tan, log, ln, abs, !): ");
            else
                Console.Write("Enter an operation (+, -, *, /, ^): ");

            string? input = Console.ReadLine()?.Trim().ToLower();

            CheckForExit(input);

            if (input != null && allOps.Contains(input))
            {
                return input;
            }

            ConsoleHelper.WriteError("Invalid operation. Please try again.");
        }
    }

    public static string ReadMenuChoice()
    {
        string[] validChoices = ["1", "2", "3", "4", "5", "6", "7"];

        while (true)
        {
            ConsoleHelper.WriteColored("  Choose an option: ", ConsoleColor.Cyan);
            string? input = Console.ReadLine()?.Trim();

            CheckForExit(input);

            if (input != null && validChoices.Contains(input))
            {
                return input;
            }

            ConsoleHelper.WriteError("Invalid choice. Please enter 1-7.");
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
