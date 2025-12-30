using System;

class BasicCalculator
{
    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        return a / b;
    }

    static void Main()
    {
        // Take input numbers from the user
        Console.Write("Enter first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = double.Parse(Console.ReadLine());

        // Ask user to choose operation
        Console.WriteLine("Choose operation (+, -, *, /): ");
        char choice = Console.ReadLine()[0];

        // Perform selected operation
        if (choice == '+')
            Console.WriteLine("Result: " + Add(num1, num2));
        else if (choice == '-')
            Console.WriteLine("Result: " + Subtract(num1, num2));
        else if (choice == '*')
            Console.WriteLine("Result: " + Multiply(num1, num2));
        else if (choice == '/')
            Console.WriteLine("Result: " + Divide(num1, num2));
        else
            Console.WriteLine("Invalid operation.");
    }
}
