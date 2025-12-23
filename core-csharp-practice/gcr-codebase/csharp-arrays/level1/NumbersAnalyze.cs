using System;

class NumberAnalyze
{
    static void Main(string[] args)
    {
        // Create an array to store 5 numbers
        int[] numbers = new int[5];

        // Taking input from the user
        Console.WriteLine("Enter 5 numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine("Checking each number:");
        Console.WriteLine();

        // Loop through the array to check positive, negative, zero, even or odd
        for (int i = 0; i < numbers.Length; i++)
        {
            int num = numbers[i];

            // If the number is positive
            if (num > 0)
            {
                // Now checking whether the positive number is even or odd
                if (num % 2 == 0)
                {
                    Console.WriteLine(num + " is a positive even number.");
                }
                else
                {
                    Console.WriteLine(num + " is a positive odd number.");
                }
            }
            // If the number is negative
            else if (num < 0)
            {
                Console.WriteLine(num + " is a negative number.");
            }
            // If the number is zero
            else
            {
                Console.WriteLine(num + " is zero.");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Comparing first and last elements:");
        Console.WriteLine();

        // Comparing the first and last elements of the array
        if (numbers[0] == numbers[numbers.Length - 1])
        {
            Console.WriteLine("First and last elements are equal.");
        }
        else if (numbers[0] > numbers[numbers.Length - 1])
        {
            Console.WriteLine("First element is greater than the last element.");
        }
        else
        {
            Console.WriteLine("First element is less than the last element.");
        }
    }
}
