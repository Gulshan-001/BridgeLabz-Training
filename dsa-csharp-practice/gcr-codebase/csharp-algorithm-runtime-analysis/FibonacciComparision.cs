using System;
using System.Diagnostics;

class FibonacciComparison
{
    static void Main()
    {
        int[] testValues = { 10, 30, 50 };

        Console.WriteLine("N\tRecursive Time\tIterative Time");

        foreach (int n in testValues)
        {
            // Measure Recursive Fibonacci
            long recursiveTime = MeasureRecursive(n);

            // Measure Iterative Fibonacci
            long iterativeTime = MeasureIterative(n);

            Console.WriteLine($"{n}\t{recursiveTime} ms\t\t{iterativeTime} ms");
        }
    }

    // Recursive Fibonacci (O(2^N))
    public static int FibonacciRecursive(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    // Iterative Fibonacci (O(N))
    public static int FibonacciIterative(int n)
    {
        if (n <= 1)
            return n;

        int a = 0, b = 1, sum = 0;

        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }

        return b;
    }

    static long MeasureRecursive(int n)
    {
        Stopwatch sw = new Stopwatch();

        // Prevent system freeze for very large N
        if (n > 40)
            return -1; // infeasible

        sw.Start();
        FibonacciRecursive(n);
        sw.Stop();

        return sw.ElapsedMilliseconds;
    }

    static long MeasureIterative(int n)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        FibonacciIterative(n);
        sw.Stop();

        return sw.ElapsedMilliseconds;
    }
}
