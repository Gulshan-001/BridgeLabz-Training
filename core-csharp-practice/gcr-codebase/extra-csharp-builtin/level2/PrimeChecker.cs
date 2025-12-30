using System;

class PrimeChecker
{
    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    static void Main()
    {
        // Take input from the user
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        // Check and display result
        if (IsPrime(num))
            Console.WriteLine("The number is a prime number.");
        else
            Console.WriteLine("The number is not a prime number.");
    }
}
