using System;

class MaximumOfThree
{
    static int GetNumber(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    static int FindMaximum(int a, int b, int c)
    {
        int max = a;

        if (b > max)
            max = b;

        if (c > max)
            max = c;

        return max;
    }

    static void Main()
    {
        // Take input from the user
        int num1 = GetNumber("Enter first number: ");
        int num2 = GetNumber("Enter second number: ");
        int num3 = GetNumber("Enter third number: ");

        // Find and display the maximum number
        int max = FindMaximum(num1, num2, num3);
        Console.WriteLine("Maximum number is: " + max);
    }
}
