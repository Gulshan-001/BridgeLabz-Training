using System;

class DateArithmetic
{
    static void Main()
    {
        // Take date input from the user
        Console.Write("Enter a date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        // Add 7 days, 1 month, and 2 years
        date = date.AddDays(7);
        date = date.AddMonths(1);
        date = date.AddYears(2);

        // Subtract 3 weeks (21 days)
        date = date.AddDays(-21);

        // Display the final date
        Console.WriteLine("Final Date: " + date.ToShortDateString());
    }
}
