using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            Console.Write("Enter rate: ");
            double rate = double.Parse(Console.ReadLine());

            Console.Write("Enter years: ");
            int years = int.Parse(Console.ReadLine());

            double interest = CalculateInterest(amount, rate, years);

            Console.WriteLine("Calculated Interest: " + interest);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid input: Amount and rate must be positive");
        }
    }

    // ================= INTEREST CALCULATION =================
    static double CalculateInterest(double amount, double rate, int years)
    {
        if (amount < 0 || rate < 0)
        {
            throw new ArgumentException();
        }

        return (amount * rate * years) / 100;
    }
}
