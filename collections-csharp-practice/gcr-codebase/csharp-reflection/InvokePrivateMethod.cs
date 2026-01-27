using System;
using System.Reflection;

class Calculator
{
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}

class Program
{
    static void Main()
    {
        // Create object
        Calculator calculator = new Calculator();

        // Get Type
        Type type = typeof(Calculator);

        // Get private method
        MethodInfo method = type.GetMethod(
            "Multiply",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        // Invoke method
        object result = method.Invoke(calculator, new object[] { 4, 5 });

        Console.WriteLine("Result: " + result);
    }
}
