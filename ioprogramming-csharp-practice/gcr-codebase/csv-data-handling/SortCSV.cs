using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        // Skip header and parse records
        var records = lines
            .Skip(1)
            .Select(line =>
            {
                string[] data = line.Split(',');
                return new
                {
                    Id = data[0],
                    Name = data[1],
                    Department = data[2],
                    Salary = double.Parse(data[3])
                };
            })
            .OrderByDescending(e => e.Salary)
            .Take(5);

        Console.WriteLine("Top 5 Highest-Paid Employees");
        Console.WriteLine("-----------------------------");

        foreach (var emp in records)
        {
            Console.WriteLine(
                $"Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}"
            );
        }
    }
}
