using System;
using System.Diagnostics;
using System.Reflection;

// Step 1: Define attribute
[AttributeUsage(AttributeTargets.Method)]
class LogExecutionTimeAttribute : Attribute
{
}

// Step 2: Class with methods to measure
class WorkService
{
    [LogExecutionTime]
    public void FastTask()
    {
        for (int i = 0; i < 100000; i++) { }
    }

    [LogExecutionTime]
    public void SlowTask()
    {
        for (int i = 0; i < 10000000; i++) { }
    }

    public void NormalTask()
    {
        for (int i = 0; i < 500000; i++) { }
    }
}

// Step 3: Executor that uses Reflection
class ExecutionTimeLogger
{
    public static void ExecuteWithLogging(object obj)
    {
        Type type = obj.GetType();

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.DeclaredOnly
        );

        foreach (MethodInfo method in methods)
        {
            // Check if method has LogExecutionTime attribute
            if (method.GetCustomAttribute<LogExecutionTimeAttribute>() != null)
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                method.Invoke(obj, null);
                stopwatch.Stop();

                Console.WriteLine(
                    $"Method: {method.Name}, Execution Time: {stopwatch.ElapsedMilliseconds} ms"
                );
            }
        }
    }
}

// Step 4: Demo
class Program
{
    static void Main()
    {
        WorkService service = new WorkService();
        ExecutionTimeLogger.ExecuteWithLogging(service);
    }
}
