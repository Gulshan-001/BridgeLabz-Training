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

        Console.WriteLine("Students scoring more than 80 marks:");
        Console.WriteLine("-----------------------------------");

        // Start from 1 to skip header
        for (int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');

            int marks = int.Parse(data[3]);

            if (marks > 80)
            {
                Console.WriteLine(
                    $"ID: {data[0]}, Name: {data[1]}, Age: {data[2]}, Marks: {data[3]}"
                );
            }
        }
    }
}
