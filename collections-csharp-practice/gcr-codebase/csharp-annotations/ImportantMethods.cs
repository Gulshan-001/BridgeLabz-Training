using System;
using System.Reflection;

// Step 1: Define custom attribute
[AttributeUsage(AttributeTargets.Method)]
class ImportantMethodAttribute : Attribute
{
    public string Level { get; }

    // Optional parameter with default value
    public ImportantMethodAttribute(string level = "HIGH")
    {
        Level = level;
    }
}

// Step 2: Apply attribute to methods
class Service
{
    [ImportantMethod]
    public void CriticalOperation()
    {
        Console.WriteLine("Critical operation executed");
    }

    [ImportantMethod("MEDIUM")]
    public void SecondaryOperation()
    {
        Console.WriteLine("Secondary operation executed");
    }

    public void NormalOperation()
    {
        Console.WriteLine("Normal operation executed");
    }
}

// Step 3: Retrieve and print annotated methods
class Program
{
    static void Main()
    {
        Type type = typeof(Service);

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.DeclaredOnly
        );

        foreach (MethodInfo method in methods)
        {
            ImportantMethodAttribute attribute =
                method.GetCustomAttribute<ImportantMethodAttribute>();

            if (attribute != null)
            {
                Console.WriteLine(
                    $"Method: {method.Name}, Importance Level: {attribute.Level}"
                );
            }
        }
    }
}
