using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter IP address: ");
        string ip = Console.ReadLine();

        string pattern = @"^((25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\.){3}(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)$";

        if (Regex.IsMatch(ip, pattern))
            Console.WriteLine("Valid IP Address");
        else
            Console.WriteLine("Invalid IP Address");
    }
}
