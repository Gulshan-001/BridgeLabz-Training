using System;
using System.Collections.Generic;
using System.Reflection;

// Step 1: Define CacheResult attribute
[AttributeUsage(AttributeTargets.Method)]
class CacheResultAttribute : Attribute
{
}

// Step 2: Service with expensive method
class MathService
{
    [CacheResult]
    public int Square(int number)
    {
        Console.WriteLine("Computing square...");
        return number * number;
    }
}

// Step 3: Cache handler
class CacheExecutor
{
    private static readonly Dictionary<string, object> cache =
        new Dictionary<string, object>();

    public static object Invoke(object obj, string methodName, params object[] args)
    {
        Type type = obj.GetType();
        MethodInfo method = type.GetMethod(methodName);

        // Check if method has CacheResult attribute
        if (method.GetCustomAttribute<CacheResultAttribute>() != null)
        {
            // Create unique cache key
            string key = $"{type.FullName}.{methodName}({string.Join(",", args)})";

            if (cache.ContainsKey(key))
            {
                Console.WriteLine("Returning cached result...");
                return cache[key];
            }

            // Execute method and cache result
            object result = method.Invoke(obj, args);
            cache[key] = result;
            return result;
        }

        // No caching
        return method.Invoke(obj, args);
    }
}

// Step 4: Demo
class Program
{
    static void Main()
    {
        MathService service = new MathService();

        Console.WriteLine(CacheExecutor.Invoke(service, "Square", 5));
        Console.WriteLine(CacheExecutor.Invoke(service, "Square", 5));
        Console.WriteLine(CacheExecutor.Invoke(service, "Square", 10));
        Console.WriteLine(CacheExecutor.Invoke(service, "Square", 10));
    }
}
