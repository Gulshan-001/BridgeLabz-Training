using System;

public class Kilometres_To_Miles
{
    public static void Main(string[] args)
    {
        Console.Write("Enter distance in kilometres (or press Enter to use 10.0): ");
        string input = Console.ReadLine();

        double kilometres;
        if (string.IsNullOrWhiteSpace(input))
        {
            kilometres = 10.0;
        }
        else if (!double.TryParse(input, out kilometres))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        double miles = kilometres * 0.621371;
        Console.WriteLine(kilometres + " kilometers is equal to " + miles + " miles.");
    }
}
