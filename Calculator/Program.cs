namespace Calculator;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("===========================");
        Console.WriteLine("   C# Console Calculator   ");
        Console.WriteLine("===========================");
        Console.WriteLine();

        bool running = true;

        while (running)
        {
            double firstNumber = ReadNumber("Enter the first number: ");
            string operation = ReadOperation();
            double secondNumber = ReadNumber("Enter the second number: ");

            double? result = Calculate(firstNumber, secondNumber, operation);

            if (result.HasValue)
            {
                Console.WriteLine($"\n  {firstNumber} {operation} {secondNumber} = {result.Value}\n");
            }
            else
            {
                Console.WriteLine("\n  Error: Cannot divide by zero.\n");
            }

            running = AskToContinue();
        }

        Console.WriteLine("Goodbye!");
    }

    public static double? Calculate(double a, double b, string operation)
    {
        return operation switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => b != 0 ? a / b : null,
            _ => throw new ArgumentException($"Unknown operation: {operation}")
        };
    }

    private static double ReadNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (double.TryParse(input, out double number))
            {
                return number;
            }

            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    private static string ReadOperation()
    {
        string[] validOperations = ["+", "-", "*", "/"];

        while (true)
        {
            Console.Write("Enter an operation (+, -, *, /): ");
            string? input = Console.ReadLine()?.Trim();

            if (input != null && validOperations.Contains(input))
            {
                return input;
            }

            Console.WriteLine("Invalid operation. Please enter +, -, *, or /.");
        }
    }

    private static bool AskToContinue()
    {
        Console.Write("Perform another calculation? (y/n): ");
        string? input = Console.ReadLine()?.Trim().ToLower();
        return input == "y" || input == "yes";
    }
}
