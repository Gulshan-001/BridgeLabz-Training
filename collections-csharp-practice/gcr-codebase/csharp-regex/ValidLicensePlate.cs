using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter license plate number: ");
        string plate = Console.ReadLine();

        string pattern = @"^[A-Z]{2}\d{4}$";

        if (Regex.IsMatch(plate, pattern))
        {
            Console.WriteLine("Valid license plate");
        }
        else
        {
            Console.WriteLine("Invalid license plate");
        }
    }
}
