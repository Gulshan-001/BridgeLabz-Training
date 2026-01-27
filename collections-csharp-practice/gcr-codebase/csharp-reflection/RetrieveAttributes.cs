using System;
using System.Reflection;

// Step 1: Create custom attribute
[AttributeUsage(AttributeTargets.Class)]
class AuthorAttribute : Attribute
{
    public string Name { get; }

    public AuthorAttribute(string name)
    {
        Name = name;
    }
}

// Step 2: Apply attribute to class
[Author("John Doe")]
class Book
{
}

// Step 3: Retrieve attribute using Reflection
class Program
{
    static void Main()
    {
        Type type = typeof(Book);

        // Get custom attributes applied to class
        object[] attributes = type.GetCustomAttributes(typeof(AuthorAttribute), false);

        foreach (AuthorAttribute attribute in attributes)
        {
            Console.WriteLine("Author: " + attribute.Name);
        }
    }
}
