using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// ================= EMPLOYEE CLASS =================
[Serializable]
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public override string ToString()
    {
        return $"{Id} | {Name} | {Department} | ₹{Salary}";
    }
}

// ================= MAIN PROGRAM =================
class Program
{
    static void Main()
    {
        string filePath = "employees.json";

        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 75000 },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance", Salary = 60000 }
        };

        // Serialize employees to file
        SaveEmployees(employees, filePath);

        // Deserialize employees from file
        List<Employee> loadedEmployees = LoadEmployees(filePath);

        Console.WriteLine("\nEmployees Retrieved From File:");
        foreach (var emp in loadedEmployees)
            Console.WriteLine(emp);
    }

    // ================= SERIALIZATION =================
    static void SaveEmployees(List<Employee> employees, string path)
    {
        string jsonData = JsonSerializer.Serialize(
            employees,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(path, jsonData);
        Console.WriteLine("Employees saved successfully.");
    }

    // ================= DESERIALIZATION =================
    static List<Employee> LoadEmployees(string path)
    {
        // Manual file existence check (no try-catch)
        if (!File.Exists(path))
        {
            Console.WriteLine("Employee file not found.");
            return new List<Employee>();
        }

        string jsonData = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<Employee>>(jsonData);
    }
}
