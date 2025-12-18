using System;

public class Simple_Interest
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the principal amount: ");
        if (!double.TryParse(Console.ReadLine(), out double principal))
        {
            Console.WriteLine("Invalid input for principal.");
            return;
        }

        Console.Write("Enter the rate of interest: ");
        if (!double.TryParse(Console.ReadLine(), out double rate))
        {
            Console.WriteLine("Invalid input for rate.");
            return;
        }

        Console.Write("Enter the time period: ");
        if (!double.TryParse(Console.ReadLine(), out double time))
        {
            Console.WriteLine("Invalid input for time.");
            return;
        }

        double simpleInterest = (principal * rate * time) / 100.0;
        Console.WriteLine("Simple Interest is: " + simpleInterest);
    }
}
