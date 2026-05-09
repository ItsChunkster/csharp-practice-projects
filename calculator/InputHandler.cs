namespace Calculator;

public static class InputHandler
{
    public static double ReadNumber(string prompt)
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

    public static string ReadOperation()
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

    public static bool AskToContinue()
    {
        Console.Write("Perform another calculation? (y/n): ");
        string? input = Console.ReadLine()?.Trim().ToLower();
        return input == "y" || input == "yes";
    }
}
