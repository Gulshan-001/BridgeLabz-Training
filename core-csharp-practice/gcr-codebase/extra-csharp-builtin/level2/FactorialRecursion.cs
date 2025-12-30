using System;

class FactorialRecursion
{
    static int GetInput()
    {
        Console.Write("Enter a number: ");
        return int.Parse(Console.ReadLine());
    }

    static int Factorial(int number)
    {
        if (number == 0 || number == 1)
            return 1;

        return number * Factorial(number - 1);
    }

    static void Main()
    {
        // Take input from the user
        int num = GetInput();

        // Calculate and display factorial
        int result = Factorial(num);
        Console.WriteLine("Factorial is: " + result);
    }
}
