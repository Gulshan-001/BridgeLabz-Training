using System;

class SumUntillZero
{
    static void Main()
    {
        double total = 0.0;
        double value;

        Console.WriteLine("Enter a number (enter 0 to stop):");
        value = Convert.ToDouble(Console.ReadLine());

        while (value != 0)
        {
            total = total + value;

            Console.WriteLine("Enter a number (enter 0 to stop):");
            value = Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine("The total sum of entered numbers is " + total);
    }
}
