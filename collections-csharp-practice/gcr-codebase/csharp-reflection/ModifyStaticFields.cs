using System;
using System.Reflection;

class Configuration
{
    private static string API_KEY = "INITIAL_KEY";
}

class Program
{
    static void Main()
    {
        // Get Type
        Type type = typeof(Configuration);

        // Get private static field
        FieldInfo apiKeyField = type.GetField(
            "API_KEY",
            BindingFlags.NonPublic | BindingFlags.Static
        );

        // Modify static field value (object parameter is null for static fields)
        apiKeyField.SetValue(null, "UPDATED_API_KEY");

        // Retrieve updated value
        string updatedKey = (string)apiKeyField.GetValue(null);

        Console.WriteLine("API_KEY: " + updatedKey);
    }
}
