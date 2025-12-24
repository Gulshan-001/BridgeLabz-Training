using System;

class Division
{
    // method to find quotient and remainder
    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int quotient = number / divisor;
        int remainder = number % divisor;
        return new int[] { quotient, remainder };
    }

    static void Main(string[] args)
    {
        // take two numbers from user
        Console.Write("Enter the number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the divisor: ");
        int divisor = Convert.ToInt32(Console.ReadLine());

        // call method to calculate quotient and remainder
        int[] result = FindRemainderAndQuotient(number, divisor);

        Console.WriteLine("Quotient: " + result[0]);
        Console.WriteLine("Remainder: " + result[1]);
    }
}
