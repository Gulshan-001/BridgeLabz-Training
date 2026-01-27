using System;
using System.Reflection;
using System.Text;

class Student
{
    public int Id;
    public string Name;
    public int Age;
}

class JsonSerializer
{
    public static string ToJson(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        StringBuilder json = new StringBuilder();
        json.Append("{");

        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo field = fields[i];
            object value = field.GetValue(obj);

            json.Append($"\"{field.Name}\": ");

            if (value is string)
                json.Append($"\"{value}\"");
            else
                json.Append(value);

            if (i < fields.Length - 1)
                json.Append(", ");
        }

        json.Append("}");
        return json.ToString();
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student
        {
            Id = 1,
            Name = "Alice",
            Age = 21
        };

        string json = JsonSerializer.ToJson(student);
        Console.WriteLine(json);
    }
}
