using System;

class Factors
{
    // method to find all factors of a number and store them in an array
    static int[] FindFactors(int number)
    {
        int count = 0;

        // first loop to count how many factors are there
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                count++;
        }

        int[] factors = new int[count];
        int index = 0;

        // second loop to store factors in the array
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                factors[index++] = i;
        }

        return factors;
    }

    // method to calculate sum of factors
    static int SumOfFactors(int[] factors)
    {
        int sum = 0;
        for (int i = 0; i < factors.Length; i++)
        {
            sum += factors[i];
        }
        return sum;
    }

    // method to calculate product of factors
    static long ProductOfFactors(int[] factors)
    {
        long product = 1;
        for (int i = 0; i < factors.Length; i++)
        {
            product *= factors[i];
        }
        return product;
    }

    // method to calculate sum of squares of factors
    static double SumOfSquaresOfFactors(int[] factors)
    {
        double sum = 0;
        for (int i = 0; i < factors.Length; i++)
        {
            sum += Math.Pow(factors[i], 2);
        }
        return sum;
    }

    static void Main(string[] args)
    {
        // take number from user
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // get factors using method
        int[] factors = FindFactors(number);

        Console.WriteLine("Factors of " + number + ":");
        for (int i = 0; i < factors.Length; i++)
        {
            Console.Write(factors[i] + " ");
        }
        Console.WriteLine();

        int sum = SumOfFactors(factors);
        long product = ProductOfFactors(factors);
        double sumOfSquares = SumOfSquaresOfFactors(factors);

        Console.WriteLine("Sum of factors: " + sum);
        Console.WriteLine("Product of factors: " + product);
        Console.WriteLine("Sum of squares of factors: " + sumOfSquares);
    }
}
