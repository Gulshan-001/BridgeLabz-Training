using System;
using System.Collections.Generic;
using System.Reflection;

class Student
{
    public int Id;
    public string Name;
    public int Age;
}

class ObjectMapper
{
    public static T ToObject<T>(Type clazz, Dictionary<string, object> properties)
    {
        // Create object dynamically
        object obj = Activator.CreateInstance(clazz);

        // Set fields using reflection
        foreach (var entry in properties)
        {
            FieldInfo field = clazz.GetField(
                entry.Key,
                BindingFlags.Public | BindingFlags.Instance
            );

            if (field != null && entry.Value != null)
            {
                field.SetValue(obj, Convert.ChangeType(entry.Value, field.FieldType));
            }
        }

        return (T)obj;
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, object> data = new Dictionary<string, object>
        {
            { "Id", 101 },
            { "Name", "Alice" },
            { "Age", 22 }
        };

        Student student = ObjectMapper.ToObject<Student>(typeof(Student), data);

        Console.WriteLine("Id: " + student.Id);
        Console.WriteLine("Name: " + student.Name);
        Console.WriteLine("Age: " + student.Age);
    }
}
