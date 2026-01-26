using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter credit card number: ");
        string card = Console.ReadLine();

        string pattern = @"^(4|5)\d{15}$";

        if (Regex.IsMatch(card, pattern))
            Console.WriteLine("Valid Credit Card");
        else
            Console.WriteLine("Invalid Credit Card");
    }
}
