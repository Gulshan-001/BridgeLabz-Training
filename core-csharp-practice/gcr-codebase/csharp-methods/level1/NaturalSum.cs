using System;

class NaturalSum
{
    // method to calculate sum of first n natural numbers using a loop
    static int CalculateSum(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i; // add current number to sum
        }
        return sum;
    }

    static void Main(string[] args)
    {
        // ask user for number of natural numbers
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // calculate sum by calling method
        int sum = CalculateSum(n);
    
        Console.WriteLine("The sum of first " + n + " natural numbers is " + sum);
    }
}
