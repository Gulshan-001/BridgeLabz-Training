using System;

public class Add_Two
{
    public static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        if (!int.TryParse(Console.ReadLine(), out int num1))
        {
            Console.WriteLine("Invalid input for first number.");
            return;
        }

        Console.Write("Enter second number: ");
        if (!int.TryParse(Console.ReadLine(), out int num2))
        {
            Console.WriteLine("Invalid input for second number.");
            return;
        }

        int sum = num1 + num2;
        Console.WriteLine("The sum of " + num1 + " and " + num2 + " is: " + sum);
    }
}
