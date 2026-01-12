using System;

class Rod
{
    public int Length;
    public int[] Price;

    public Rod(int length, int[] price)
    {
        Length = length;
        Price = price;
    }
}

class RodCutter
{
    // Optimized revenue using DP
    public int CalculateMaxRevenue(Rod rod)
    {
        int[] dp = new int[rod.Length + 1];

        for (int i = 1; i <= rod.Length; i++)
        {
            int max = 0;
            for (int j = 1; j <= i && j < rod.Price.Length; j++)
            {
                int value = rod.Price[j] + dp[i - j];
                if (value > max)
                    max = value;
            }
            dp[i] = max;
        }
        return dp[rod.Length];
    }

    // Non-optimized revenue
    public int CalculateSimpleRevenue(Rod rod)
    {
        if (rod.Length < rod.Price.Length)
            return rod.Price[rod.Length];

        return 0;
    }
}

class FactoryApp
{
    static void Main()
    {
        // Fixed price chart (index = length)
        int[] price = { 0, 1, 5, 8, 9, 10, 17, 17, 20 };

        RodCutter cutter = new RodCutter();

        // Scenario A
        Rod defaultRod = new Rod(8, price);
        Console.WriteLine("Scenario A: Optimized Cutting");
        Console.WriteLine("Max Revenue: " +
            cutter.CalculateMaxRevenue(defaultRod));

        // Scenario B – USER INPUT
        Console.WriteLine("\nScenario B: Custom Length Order");
        Console.Write("Enter custom rod length: ");
        int userLength = int.Parse(Console.ReadLine());

        Rod userRod = new Rod(userLength, price);
        int revenue = cutter.CalculateMaxRevenue(userRod);

        Console.WriteLine("Revenue for custom length: " + revenue);

        // Scenario C
        Console.WriteLine("\nScenario C: Non-Optimized Strategy");
        Console.WriteLine("Revenue without optimization: " +
            cutter.CalculateSimpleRevenue(defaultRod));
    }
}
