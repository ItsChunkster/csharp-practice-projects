namespace TerminalCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            ShowHeader();
            RunCalculatorLoop();
        }
        catch (ExitException)
        {
        }

        Console.WriteLine("Goodbye!");
    }

    private static void ShowHeader()
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine("       Terminal Calculator          ");
        Console.WriteLine("===================================");
        Console.WriteLine("  Type 'exit' or 'quit' to leave.  ");
        Console.WriteLine("===================================");
        Console.WriteLine();
    }

    private static void RunCalculatorLoop()
    {
        bool running = true;

        while (running)
        {
            double firstNumber = InputHandler.ReadNumber("Enter the first number: ");
            string operation = InputHandler.ReadOperation();
            double secondNumber = InputHandler.ReadNumber("Enter the second number: ");

            double? result = CalculatorEngine.Calculate(firstNumber, secondNumber, operation);

            Console.WriteLine();
            if (result.HasValue)
            {
                Console.WriteLine($"  {firstNumber} {operation} {secondNumber} = {result.Value}");
            }
            else
            {
                Console.WriteLine("  Error: Cannot divide by zero.");
            }
            Console.WriteLine();

            running = InputHandler.AskToContinue();

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
            }
        }
    }
}
