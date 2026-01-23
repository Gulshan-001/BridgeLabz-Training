using System;

// ================= CUSTOM EXCEPTION =================
class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            ValidateAge(age);

            Console.WriteLine("Access granted!");
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // ================= AGE VALIDATION =================
    static void ValidateAge(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException("Age must be 18 or above");
        }
    }
}
