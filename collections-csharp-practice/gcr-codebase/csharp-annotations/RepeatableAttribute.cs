using System;
using System.Reflection;

// Step 1: Define repeatable attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class BugReportAttribute : Attribute
{
    public string Description { get; }

    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

// Step 2: Apply attribute multiple times
class Feature
{
    [BugReport("Null reference occurs on invalid input")]
    [BugReport("Performance issue under heavy load")]
    public void Execute()
    {
        Console.WriteLine("Executing feature...");
    }
}

// Step 3: Retrieve and print all bug reports
class Program
{
    static void Main()
    {
        Type type = typeof(Feature);
        MethodInfo method = type.GetMethod("Execute");

        BugReportAttribute[] bugReports =
            method.GetCustomAttributes<BugReportAttribute>();

        foreach (BugReportAttribute report in bugReports)
        {
            Console.WriteLine("Bug: " + report.Description);
        }
    }
}
