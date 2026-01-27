using System;
using System.Reflection;

class ReflectionDemo
{
    static void Main()
    {
        Console.Write("Enter fully qualified class name: ");
        string className = Console.ReadLine();

        Type type = Type.GetType(className);

        if (type == null)
        {
            Console.WriteLine("Class not found.");
            return;
        }

        Console.WriteLine("\nClass Name: " + type.FullName);

        // Constructors
        Console.WriteLine("\nConstructors:");
        ConstructorInfo[] constructors = type.GetConstructors();
        foreach (ConstructorInfo constructor in constructors)
        {
            Console.WriteLine(constructor);
        }

        // Fields
        Console.WriteLine("\nFields:");
        FieldInfo[] fields = type.GetFields(
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static
        );

        foreach (FieldInfo field in fields)
        {
            Console.WriteLine(field.FieldType.Name + " " + field.Name);
        }

        // Methods
        Console.WriteLine("\nMethods:");
        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly
        );

        foreach (MethodInfo method in methods)
        {
            Console.WriteLine(method);
        }
    }
}
