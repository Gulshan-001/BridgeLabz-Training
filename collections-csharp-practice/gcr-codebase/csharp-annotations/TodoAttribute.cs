using System;
using System.Reflection;

// Step 1: Define Todo attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class TodoAttribute : Attribute
{
    public string Task { get; }
    public string AssignedTo { get; }
    public string Priority { get; }

    public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = priority;
    }
}

// Step 2: Apply attribute to methods
class FeatureModule
{
    [Todo("Add input validation", "Alice", "HIGH")]
    [Todo("Improve performance", "Bob")]
    public void ProcessData()
    {
    }

    [Todo("Add logging support", "Charlie")]
    public void ExportData()
    {
    }
}

// Step 3: Retrieve and print all pending tasks
class Program
{
    static void Main()
    {
        Type type = typeof(FeatureModule);

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.DeclaredOnly
        );

        foreach (MethodInfo method in methods)
        {
            TodoAttribute[] todos =
                method.GetCustomAttributes<TodoAttribute>();

            foreach (TodoAttribute todo in todos)
            {
                Console.WriteLine(
                    $"Method: {method.Name}, Task: {todo.Task}, Assigned To: {todo.AssignedTo}, Priority: {todo.Priority}"
                );
            }
        }
    }
}
