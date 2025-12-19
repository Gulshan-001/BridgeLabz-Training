using System;

class Arithmetic
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        int sum = a + b;
        int diff = a - b;
        int product = a * b;
        double quotient = (double)a / b;

        Console.WriteLine(
            "The additon, subtraction, multiplication and division of 2 numbers " +
            a + " and " + b + " is " +
            sum + ", " + diff + ", " + product + " and " + quotient
        );
    }
}
