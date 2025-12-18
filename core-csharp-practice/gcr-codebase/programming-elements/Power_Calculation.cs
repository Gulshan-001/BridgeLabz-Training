using System;

public class Power_Calculation
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the base number: ");
        if (!double.TryParse(Console.ReadLine(), out double baseNum))
        {
            Console.WriteLine("Invalid base input.");
            return;
        }

        Console.Write("Enter the exponent: ");
        if (!double.TryParse(Console.ReadLine(), out double exponent))
        {
            Console.WriteLine("Invalid exponent input.");
            return;
        }

        double result = Math.Pow(baseNum, exponent);
        Console.WriteLine(baseNum + " raised to the power of " + exponent + " is: " + result);
    }
}
