namespace TerminalCalculator;

public class Program
{
    private static bool _scientificMode;

    public static void Main(string[] args)
    {
        try
        {
            ShowHeader();
            RunMainMenu();
        }
        catch (ExitException)
        {
        }

        Console.WriteLine();
        ConsoleHelper.WriteInfo("Goodbye!");
    }

    private static void ShowHeader()
    {
        Console.Clear();
        ConsoleHelper.WriteHeader("==============================");
        ConsoleHelper.WriteHeader("     TERMINAL CALCULATOR      ");
        ConsoleHelper.WriteHeader("==============================");
        Console.WriteLine();
        ConsoleHelper.WriteWarning("  Type 'exit' or 'quit' to leave.");
        ConsoleHelper.WriteWarning("  Type 'mr' for memory recall.");
        Console.WriteLine();
    }

    private static void ShowMenu()
    {
        string mode = _scientificMode ? "ON" : "OFF";
        ConsoleHelper.WriteInfo("Select an option:");
        Console.WriteLine("  1. Calculate");
        Console.WriteLine("  2. View History");
        Console.WriteLine("  3. Clear History");
        Console.WriteLine("  4. Store to Memory");
        Console.WriteLine("  5. Recall Memory");
        Console.WriteLine("  6. Clear Memory");
        Console.WriteLine($"  7. Scientific Mode [{mode}]");
        Console.WriteLine("  8. Exit");
        Console.WriteLine();
    }

    private static void RunMainMenu()
    {
        while (true)
        {
            ShowMenu();
            string choice = InputHandler.ReadMenuChoice();

            switch (choice)
            {
                case "1":
                    RunCalculation();
                    break;
                case "2":
                    History.Show();
                    break;
                case "3":
                    History.Clear();
                    break;
                case "4":
                    StoreToMemory();
                    break;
                case "5":
                    Memory.Recall();
                    Console.WriteLine();
                    break;
                case "6":
                    Memory.Clear();
                    Console.WriteLine();
                    break;
                case "7":
                    _scientificMode = !_scientificMode;
                    string state = _scientificMode ? "ON" : "OFF";
                    ConsoleHelper.WriteSuccess($"  Scientific mode: {state}");
                    Console.WriteLine();
                    break;
                case "8":
                    throw new ExitException();
            }
        }
    }

    private static void RunCalculation()
    {
        string operation = InputHandler.ReadOperation(_scientificMode);
        string[] unaryOps = ["sqrt", "sin", "cos", "tan", "log", "ln", "abs", "!"];

        if (unaryOps.Contains(operation))
        {
            RunUnaryCalculation(operation);
        }
        else
        {
            RunBinaryCalculation(operation);
        }
    }

    private static void RunBinaryCalculation(string operation)
    {
        double firstNumber = InputHandler.ReadNumber("Enter the first number: ");
        double secondNumber = InputHandler.ReadNumber("Enter the second number: ");

        double? result = CalculatorEngine.Calculate(firstNumber, secondNumber, operation);

        Console.WriteLine();
        if (result.HasValue)
        {
            string entry = $"{firstNumber} {operation} {secondNumber} = {result.Value}";
            ConsoleHelper.WriteSuccess($"  {entry}");
            History.Add(entry);
        }
        else
        {
            ConsoleHelper.WriteError("  Error: Cannot divide by zero.");
        }
        Console.WriteLine();
    }

    private static void RunUnaryCalculation(string operation)
    {
        double value = InputHandler.ReadNumber("Enter the value: ");

        try
        {
            double result = operation switch
            {
                "sqrt" => CalculatorEngine.SquareRoot(value),
                "sin" => CalculatorEngine.Sine(value),
                "cos" => CalculatorEngine.Cosine(value),
                "tan" => CalculatorEngine.Tangent(value),
                "log" => CalculatorEngine.Log(value),
                "ln" => CalculatorEngine.Ln(value),
                "abs" => CalculatorEngine.Absolute(value),
                "!" => CalculatorEngine.Factorial((int)value),
                _ => throw new ArgumentException($"Unknown operation: {operation}")
            };

            string entry = $"{operation}({value}) = {result}";
            Console.WriteLine();
            ConsoleHelper.WriteSuccess($"  {entry}");
            History.Add(entry);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine();
            ConsoleHelper.WriteError($"  Error: {ex.Message}");
        }
        Console.WriteLine();
    }

    private static void StoreToMemory()
    {
        double value = InputHandler.ReadNumber("Enter value to store: ");
        Memory.Store(value);
        Console.WriteLine();
    }
}
