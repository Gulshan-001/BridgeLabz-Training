using System;
using System.Diagnostics;
using System.Reflection;

class Workload
{
    public void FastMethod()
    {
        for (int i = 0; i < 100000; i++) { }
    }

    public void SlowMethod()
    {
        for (int i = 0; i < 10000000; i++) { }
    }
}

class MethodTimer
{
    public static void MeasureExecutionTime(object obj)
    {
        Type type = obj.GetType();

        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.DeclaredOnly
        );

        foreach (MethodInfo method in methods)
        {
            if (method.GetParameters().Length == 0)
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                method.Invoke(obj, null);
                stopwatch.Stop();

                Console.WriteLine(
                    $"Method: {method.Name}, Time: {stopwatch.ElapsedMilliseconds} ms"
                );
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Workload workload = new Workload();
        MethodTimer.MeasureExecutionTime(workload);
    }
}
