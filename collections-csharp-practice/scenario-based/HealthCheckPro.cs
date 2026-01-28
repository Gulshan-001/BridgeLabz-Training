using System;
using System.Reflection;
using System.Collections.Generic;

// =====================
// Step 1: Define API annotations
// =====================

[AttributeUsage(AttributeTargets.Method)]
class PublicAPIAttribute : Attribute
{
    public string Description { get; }

    public PublicAPIAttribute(string description)
    {
        Description = description;
    }
}

[AttributeUsage(AttributeTargets.Method)]
class RequiresAuthAttribute : Attribute
{
}

// =====================
// Step 2: Sample Controller Classes
// =====================

class LabTestController
{
    [PublicAPI("Get all available lab tests")]
    public void GetLabTests()
    {
    }

    [PublicAPI("Book a lab test")]
    [RequiresAuth]
    public void BookLabTest()
    {
    }

    // Missing annotations (should be flagged)
    public void InternalAudit()
    {
    }
}

class PatientController
{
    [PublicAPI("Get patient details")]
    [RequiresAuth]
    public void GetPatient()
    {
    }
}

// =====================
// Step 3: HealthCheckPro Scanner
// =====================

class HealthCheckPro
{
    public static void ScanAndGenerateDocs()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        List<string> documentation = new List<string>();

        foreach (Type type in assembly.GetTypes())
        {
            // Only scan controller classes
            if (!type.Name.EndsWith("Controller"))
                continue;

            Console.WriteLine($"\nScanning Controller: {type.Name}");

            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly
            );

            foreach (MethodInfo method in methods)
            {
                var publicApi = method.GetCustomAttribute<PublicAPIAttribute>();
                var requiresAuth = method.GetCustomAttribute<RequiresAuthAttribute>();

                if (publicApi == null)
                {
                    Console.WriteLine(
                        $"WARNING: {method.Name} is missing [PublicAPI] annotation"
                    );
                    continue;
                }

                string authInfo = requiresAuth != null
                    ? "Authentication Required"
                    : "No Authentication";

                documentation.Add(
                    $"API: {method.Name}\n" +
                    $"Description: {publicApi.Description}\n" +
                    $"Security: {authInfo}\n"
                );
            }
        }

        // =====================
        // Step 4: Auto-generated API Documentation
        // =====================
        Console.WriteLine("\n=== AUTO-GENERATED API DOCUMENTATION ===");
        foreach (string doc in documentation)
        {
            Console.WriteLine(doc);
        }
    }
}

// =====================
// Step 5: Demo
// =====================

class Program
{
    static void Main()
    {
        HealthCheckPro.ScanAndGenerateDocs();
    }
}
