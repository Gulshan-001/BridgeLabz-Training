using System;

class ArmstrongNumber
{
    static void Main(string[] args)
    {
        // Step 1: Get user input
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        // Step 2: Initialize sum and store original number
        int sum = 0;
        int originalNumber = number;

        // Step 3: Loop through each digit
        while (originalNumber != 0)
        {
            // Find the last digit
            int digit = originalNumber % 10;

            // Add the cube of the digit to sum
            sum += digit * digit * digit;

            // Remove the last digit from originalNumber
            originalNumber /= 10;
        }

        // Step 4: Check if the sum equals the original number
        if (sum == number)
        {
            Console.WriteLine(number + " is an Armstrong number.");
        }
        else
        {
            Console.WriteLine(number + " is not an Armstrong number.");
        }
    }
}
