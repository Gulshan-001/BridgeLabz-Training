using System;

class OddEvenArray
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a natural number:");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check if the number is a natural number
        if (number <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a natural number.");
            return;
        }

        // Creating arrays for odd and even numbers
        int[] oddNumbers = new int[number / 2 + 1];
        int[] evenNumbers = new int[number / 2 + 1];

        // Index variables to track positions
        int oddIndex = 0;
        int evenIndex = 0;

        // Loop from 1 to the given number
        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                evenNumbers[evenIndex] = i;
                evenIndex++;
            }
            else
            {
                oddNumbers[oddIndex] = i;
                oddIndex++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Odd Numbers:");
        for (int i = 0; i < oddIndex; i++)
        {
            Console.Write(oddNumbers[i] + " ");
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Even Numbers:");
        for (int i = 0; i < evenIndex; i++)
        {
            Console.Write(evenNumbers[i] + " ");
        }
    }
}
