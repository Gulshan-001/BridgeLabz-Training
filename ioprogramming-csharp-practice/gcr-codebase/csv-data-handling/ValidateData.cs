using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = "users.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        // Regex patterns
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        string phonePattern = @"^\d{10}$";

        Console.WriteLine("Invalid Records");
        Console.WriteLine("----------------");

        // Skip header row
        for (int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');

            string email = data[2];
            string phone = data[3];

            bool isEmailValid = Regex.IsMatch(email, emailPattern);
            bool isPhoneValid = Regex.IsMatch(phone, phonePattern);

            if (!isEmailValid || !isPhoneValid)
            {
                Console.WriteLine($"Row {i + 1}: {lines[i]}");

                if (!isEmailValid)
                    Console.WriteLine("  Error: Invalid email format");

                if (!isPhoneValid)
                    Console.WriteLine("  Error: Phone number must contain exactly 10 digits");
            }
        }
    }
}
