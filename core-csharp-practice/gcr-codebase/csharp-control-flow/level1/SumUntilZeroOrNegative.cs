using System;

class SumUntilZeroOrNegative
{
    static void Main()
    {
        double total = 0.0;

        while (true)
        {
            Console.WriteLine("Enter a number (enter 0 or a negative number to stop):");
            double value = Convert.ToDouble(Console.ReadLine());

            if (value <= 0)
            {
                break;
            }

            total = total + value;
        }

        Console.WriteLine("The total sum of entered numbers is " + total);
    }
}
