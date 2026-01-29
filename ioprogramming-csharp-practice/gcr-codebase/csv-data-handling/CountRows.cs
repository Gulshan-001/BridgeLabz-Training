using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "students.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        // Exclude header row
        int recordCount = lines.Length - 1;

        Console.WriteLine("Number of records: " + recordCount);
    }
}
