using System;
using System.Reflection;

// Step 1: Define MaxLength attribute
[AttributeUsage(AttributeTargets.Field)]
class MaxLengthAttribute : Attribute
{
    public int Value { get; }

    public MaxLengthAttribute(int value)
    {
        Value = value;
    }
}

// Step 2: Apply attribute to field
class User
{
    [MaxLength(10)]
    public string Username;

    public User(string username)
    {
        ValidateMaxLength(username);
        Username = username;
    }

    private void ValidateMaxLength(string value)
    {
        FieldInfo field =
            typeof(User).GetField(nameof(Username));

        MaxLengthAttribute attribute =
            field.GetCustomAttribute<MaxLengthAttribute>();

        if (attribute != null && value.Length > attribute.Value)
        {
            throw new ArgumentException(
                $"Username exceeds maximum length of {attribute.Value}"
            );
        }
    }
}

// Step 3: Demo
class Program
{
    static void Main()
    {
        try
        {
            User user = new User("VeryLongUsername");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        User validUser = new User("Alice");
        Console.WriteLine("Valid username: " + validUser.Username);
    }
}
