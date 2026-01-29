using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}

class Program
{
    static void Main()
    {
        ConvertJsonToCsv("students.json", "students.csv");
        ConvertCsvToJson("students.csv", "students_back.json");
    }

    // JSON -> CSV
    static void ConvertJsonToCsv(string jsonFile, string csvFile)
    {
        string json = File.ReadAllText(jsonFile);
        List<Student> students = JsonSerializer.Deserialize<List<Student>>(json);

        using (StreamWriter writer = new StreamWriter(csvFile))
        {
            writer.WriteLine("Id,Name,Age,Marks");

            foreach (var s in students)
            {
                writer.WriteLine($"{s.Id},{s.Name},{s.Age},{s.Marks}");
            }
        }

        Console.WriteLine("JSON converted to CSV");
    }

    // CSV -> JSON
    static void ConvertCsvToJson(string csvFile, string jsonFile)
    {
        string[] lines = File.ReadAllLines(csvFile);
        List<Student> students = new List<Student>();

        for (int i = 1; i < lines.Length; i++) // skip header
        {
            string[] data = lines[i].Split(',');

            students.Add(new Student
            {
                Id = int.Parse(data[0]),
                Name = data[1],
                Age = int.Parse(data[2]),
                Marks = int.Parse(data[3])
            });
        }

        string jsonOutput = JsonSerializer.Serialize(
            students,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(jsonFile, jsonOutput);

        Console.WriteLine("CSV converted back to JSON");
    }
}
