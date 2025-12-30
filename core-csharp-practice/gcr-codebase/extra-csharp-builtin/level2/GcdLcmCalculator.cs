using System;

class GcdLcmCalculator
{
    static int GetNumber(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    static int FindLCM(int a, int b)
    {
        return (a * b) / FindGCD(a, b);
    }

    static void Main()
    {
        // Take input from the user
        int num1 = GetNumber("Enter first number: ");
        int num2 = GetNumber("Enter second number: ");

        // Calculate GCD and LCM
        int gcd = FindGCD(num1, num2);
        int lcm = FindLCM(num1, num2);

        // Display results
        Console.WriteLine("GCD: " + gcd);
        Console.WriteLine("LCM: " + lcm);
    }
}
