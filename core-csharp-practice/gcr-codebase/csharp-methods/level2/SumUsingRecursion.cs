using System;

class SumUsingRecursion
{
    // method to find sum of n natural numbers using recursion
    static int RecursiveSum(int n)
    {
        if (n == 0)
            return 0;

        return n + RecursiveSum(n - 1);
    }

    // method to find sum of n natural numbers using formula n*(n+1)/2
    static int FormulaSum(int n)
    {
        return n * (n + 1) / 2;
    }

    static void Main(string[] args)
    {
        // take input number from user
        Console.Write("Enter a natural number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // check if the number is a natural number
        if (n <= 0)
        {
            Console.WriteLine("Please enter a valid natural number.");
            return;
        }

        // calculate sum using recursion
        int recursiveResult = RecursiveSum(n);

        // calculate sum using formula
        int formulaResult = FormulaSum(n);

        Console.WriteLine("Sum using recursion: " + recursiveResult);
        Console.WriteLine("Sum using formula: " + formulaResult);

        // compare both results
        if (recursiveResult == formulaResult)
            Console.WriteLine("Both results are equal. Computation is correct.");
        else
            Console.WriteLine("Results are not equal. Computation is incorrect.");
    }
}
