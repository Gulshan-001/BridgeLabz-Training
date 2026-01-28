using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

// =====================
// Step 1: Define AuditTrail attribute
// =====================

[AttributeUsage(AttributeTargets.Method)]
class AuditTrailAttribute : Attribute
{
    public string Action { get; }
    public string PerformedBy { get; }

    public AuditTrailAttribute(string action, string performedBy)
    {
        Action = action;
        PerformedBy = performedBy;
    }
}

// =====================
// Step 2: Sample system classes
// =====================

class UserActions
{
    [AuditTrail("User Login", "User")]
    public void Login()
    {
    }

    [AuditTrail("File Upload", "User")]
    public void UploadFile()
    {
    }

    [AuditTrail("Delete Record", "Admin")]
    public void DeleteRecord()
    {
    }

    public void HelperMethod()
    {
        // Not audited
    }
}

// =====================
// Step 3: EventTracker (Reflection + JSON)
// =====================

class EventTracker
{
    public static void GenerateAuditLogs()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        List<string> auditLogs = new List<string>();

        foreach (Type type in assembly.GetTypes())
        {
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly
            );

            foreach (MethodInfo method in methods)
            {
                AuditTrailAttribute attribute =
                    method.GetCustomAttribute<AuditTrailAttribute>();

                if (attribute == null)
                    continue;

                string jsonLog = BuildJsonLog(
                    type.Name,
                    method.Name,
                    attribute.Action,
                    attribute.PerformedBy
                );

                auditLogs.Add(jsonLog);
            }
        }

        // Print generated logs
        Console.WriteLine("=== AUDIT LOGS ===");
        foreach (string log in auditLogs)
        {
            Console.WriteLine(log);
        }
    }

    private static string BuildJsonLog(
        string className,
        string methodName,
        string action,
        string performedBy)
    {
        StringBuilder json = new StringBuilder();
        json.Append("{");
        json.Append($"\"timestamp\": \"{DateTime.UtcNow:o}\", ");
        json.Append($"\"class\": \"{className}\", ");
        json.Append($"\"method\": \"{methodName}\", ");
        json.Append($"\"action\": \"{action}\", ");
        json.Append($"\"performedBy\": \"{performedBy}\"");
        json.Append("}");

        return json.ToString();
    }
}

// =====================
// Step 4: Demo
// =====================

class Program
{
    static void Main()
    {
        EventTracker.GenerateAuditLogs();
    }
}
