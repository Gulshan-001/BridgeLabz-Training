using System;

class DigitsCount
{
    static void Main(string[] args)
    {
        // Step 1: Get user input
        Console.WriteLine("Enter an integer:");
        int number = Convert.ToInt32(Console.ReadLine());

        // Step 2: Initialize count variable
        int count = 0;
        int tempNumber = Math.Abs(number); // Handle negative numbers

        // Step 3: Loop until tempNumber becomes 0
        while (tempNumber != 0)
        {
            tempNumber /= 10; // Remove the last digit
            count++;           // Increment count
        }

        // Step 4: Display the number of digits
        Console.WriteLine("The number of digits in " + number + " is " + count);
    }
}
