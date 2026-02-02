using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Xml.Linq;
using System.Data.SqlClient;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Subjects { get; set; }
}

class Car
{
    public string Brand { get; set; }
    public int Year { get; set; }
}

class Program
{
    static void Main()
    {
        // 1. Create JSON object
        var student = new Student
        {
            Name = "Alice",
            Age = 22,
            Subjects = new List<string> { "Math", "Physics" }
        };
        Console.WriteLine(JsonSerializer.Serialize(student, new JsonSerializerOptions { WriteIndented = true }));

        // 2. C# object to JSON
        var car = new Car { Brand = "Tesla", Year = 2023 };
        Console.WriteLine(JsonSerializer.Serialize(car));

        // 3. Read JSON & extract fields
        var json = @"{""name"":""Bob"",""email"":""bob@gmail.com"",""age"":30}";
        var doc = JsonDocument.Parse(json);
        Console.WriteLine(doc.RootElement.GetProperty("name"));
        Console.WriteLine(doc.RootElement.GetProperty("email"));

        // 4. Merge JSON objects
        var merged = new { name = "Alice", age = 22, email = "alice@gmail.com" };
        Console.WriteLine(JsonSerializer.Serialize(merged));

        // 5. JSON Schema Validation
        string schemaJson = @"{
          'type':'object',
          'properties':{
            'email':{'type':'string','format':'email'}
          },
          'required':['email']
        }";
        JObject obj = JObject.Parse(@"{""email"":""test@gmail.com""}");
        Console.WriteLine(obj.IsValid(JSchema.Parse(schemaJson)));

        // 6. List to JSON array
        var list = new List<Student> { student };
        Console.WriteLine(JsonSerializer.Serialize(list));

        // 7. Filter age > 25
        var people = JsonSerializer.Deserialize<List<Student>>(
            @"[{""Name"":""A"",""Age"":20},{""Name"":""B"",""Age"":30}]");
        foreach (var p in people)
            if (p.Age > 25)
                Console.WriteLine(p.Name);
    }
}
