namespace Calculator;

public static class CalculatorEngine
{
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
}
