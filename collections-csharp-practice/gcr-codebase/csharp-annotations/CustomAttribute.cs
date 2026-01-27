using System;
using System.Reflection;

// Step 1: Define custom attribute
[AttributeUsage(AttributeTargets.Method)]
class TaskInfoAttribute : Attribute
{
    public int Priority { get; }
    public string AssignedTo { get; }

    public TaskInfoAttribute(int priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

// Step 2: Apply attribute to a method
class TaskManager
{
    [TaskInfo(1, "Alice")]
    public void ProcessTask()
    {
        Console.WriteLine("Processing task...");
    }
}

// Step 3: Retrieve attribute using Reflection
class Program
{
    static void Main()
    {
        Type type = typeof(TaskManager);
        MethodInfo method = type.GetMethod("ProcessTask");

        TaskInfoAttribute attribute =
            method.GetCustomAttribute<TaskInfoAttribute>();

        if (attribute != null)
        {
            Console.WriteLine("Priority: " + attribute.Priority);
            Console.WriteLine("Assigned To: " + attribute.AssignedTo);
        }
    }
}
