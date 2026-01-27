using System;
using System.Reflection;
using System.Text;

// Step 1: Define JsonField attribute
[AttributeUsage(AttributeTargets.Field)]
class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }
}

// Step 2: Apply attribute to fields
class User
{
    [JsonField(Name = "user_id")]
    public int Id;

    [JsonField(Name = "user_name")]
    public string Username;

    [JsonField(Name = "user_age")]
    public int Age;

    // Field without attribute will be ignored
    public string InternalCode;
}

// Step 3: Custom JSON serializer
class JsonSerializer
{
    public static string Serialize(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(
            BindingFlags.Public | BindingFlags.Instance
        );

        StringBuilder json = new StringBuilder();
        json.Append("{");

        bool first = true;

        foreach (FieldInfo field in fields)
        {
            JsonFieldAttribute attribute =
                field.GetCustomAttribute<JsonFieldAttribute>();

            if (attribute == null)
                continue;

            if (!first)
                json.Append(", ");

            object value = field.GetValue(obj);
            string key = attribute.Name;

            json.Append($"\"{key}\": ");

            if (value is string)
                json.Append($"\"{value}\"");
            else
                json.Append(value);

            first = false;
        }

        json.Append("}");
        return json.ToString();
    }
}

// Step 4: Demo
class Program
{
    static void Main()
    {
        User user = new User
        {
            Id = 101,
            Username = "Alice",
            Age = 22,
            InternalCode = "SECRET"
        };

        string json = JsonSerializer.Serialize(user);
        Console.WriteLine(json);
    }
}
