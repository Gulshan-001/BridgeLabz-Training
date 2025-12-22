using System;

class Factorial
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        int factorial = 1;
        int i = 1;

        while (i <= number)
        {
            factorial *= i;
            i++;
        }

        Console.WriteLine("Factorial of " + number + " is: " + factorial);
    }
}
