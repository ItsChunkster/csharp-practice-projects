using System;

namespace TerminalCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            InputHandler inputHandler = new InputHandler();

            bool running = true;

            while (running)
            {
                Console.Clear();
                PrintHeader();

                Console.WriteLine("Select an operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    running = false;
                    continue;
                }

                double firstNumber = inputHandler.GetNumber("Enter first number: ");
                double secondNumber = inputHandler.GetNumber("Enter second number: ");

                double result = 0;
                bool validOperation = true;

                switch (choice)
                {
                    case "1":
                        result = calculator.Add(firstNumber, secondNumber);
                        break;
                    case "2":
                        result = calculator.Subtract(firstNumber, secondNumber);
                        break;
                    case "3":
                        result = calculator.Multiply(firstNumber, secondNumber);
                        break;
                    case "4":
                        result = calculator.Divide(firstNumber, secondNumber, out validOperation);
                        break;
                    default:
                        Console.WriteLine("\nInvalid selection.");
                        validOperation = false;
                        break;
                }

                if (validOperation)
                {
                    Console.WriteLine($"\nResult: {result}");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void PrintHeader()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("     TERMINAL CALCULATOR     ");
            Console.WriteLine("==============================\n");
        }
    }
}
