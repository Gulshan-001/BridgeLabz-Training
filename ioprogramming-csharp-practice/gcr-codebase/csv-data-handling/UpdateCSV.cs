using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "employees.csv";
        string outputFile = "employees_updated.csv";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(inputFile);

        // Create array for updated records
        string[] updatedLines = new string[lines.Length];

        // Copy header
        updatedLines[0] = lines[0];

        // Process records
        for (int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');

            string department = data[2];
            double salary = double.Parse(data[3]);

            if (department.Equals("IT", StringComparison.OrdinalIgnoreCase))
            {
                salary = salary * 1.10; // Increase by 10%
            }

            updatedLines[i] =
                $"{data[0]},{data[1]},{data[2]},{salary}";
        }

        // Write to new CSV file
        File.WriteAllLines(outputFile, updatedLines);

        Console.WriteLine("Updated CSV file created successfully.");
    }
}
