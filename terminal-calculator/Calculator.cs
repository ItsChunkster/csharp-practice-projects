namespace TerminalCalculator;

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
            "^" => Math.Pow(a, b),
            _ => throw new ArgumentException($"Unknown operation: {operation}")
        };
    }

    public static double SquareRoot(double value)
    {
        return Math.Sqrt(value);
    }

    public static double Sine(double degrees)
    {
        return Math.Sin(DegreesToRadians(degrees));
    }

    public static double Cosine(double degrees)
    {
        return Math.Cos(DegreesToRadians(degrees));
    }

    public static double Tangent(double degrees)
    {
        return Math.Tan(DegreesToRadians(degrees));
    }

    public static double Log(double value)
    {
        return Math.Log10(value);
    }

    public static double Ln(double value)
    {
        return Math.Log(value);
    }

    public static double Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("Factorial is not defined for negative numbers.");
        if (n > 170)
            throw new ArgumentException("Factorial input too large (max 170).");

        double result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    public static double Absolute(double value)
    {
        return Math.Abs(value);
    }

    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }
}
