using System;

class FibonacciGenerator
{
    static void PrintFibonacci(int terms)
    {
        int a = 0, b = 1;

        for (int i = 1; i <= terms; i++)
        {
            Console.Write(a + " ");

            int next = a + b;
            a = b;
            b = next;
        }
    }

    static void Main()
    {
        // Take number of terms from the user
        Console.Write("Enter number of terms: ");
        int terms = int.Parse(Console.ReadLine());

        // Generate and print Fibonacci sequence
        PrintFibonacci(terms);
    }
}
