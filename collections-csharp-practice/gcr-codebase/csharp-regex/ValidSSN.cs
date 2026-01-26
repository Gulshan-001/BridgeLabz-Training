using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string ssn = "123-45-6789";

        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        if (Regex.IsMatch(ssn, pattern))
            Console.WriteLine("Valid SSN");
        else
            Console.WriteLine("Invalid SSN");
    }
}
