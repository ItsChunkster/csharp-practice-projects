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
            double firstNumber = InputHandler.ReadNumber("Enter the first number: ");
            string operation = InputHandler.ReadOperation();
            double secondNumber = InputHandler.ReadNumber("Enter the second number: ");

            double? result = CalculatorEngine.Calculate(firstNumber, secondNumber, operation);

            if (result.HasValue)
            {
                Console.WriteLine($"\n  {firstNumber} {operation} {secondNumber} = {result.Value}\n");
            }
            else
            {
                Console.WriteLine("\n  Error: Cannot divide by zero.\n");
            }

            running = InputHandler.AskToContinue();
        }

        Console.WriteLine("Goodbye!");
    }
}
