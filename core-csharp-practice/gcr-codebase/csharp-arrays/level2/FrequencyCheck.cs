using System;

class FrequencyCheck
{
    static void Main(string[] args)
    {
        // Ask the user to enter a number
        Console.WriteLine("Enter the number:");
        int number = Convert.ToInt32(Console.ReadLine());

        int count = 0;
        int temp = number;

        // Count how many digits are present in the number
        while (temp != 0)
        {
            count++;
            temp /= 10;
        }

        // Array to store individual digits
        int[] digits = new int[count];
        temp = number;

        // Extract each digit and store it in the array
        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }

        // Frequency array to store count of digits from 0 to 9
        int[] frequency = new int[10];

        // Increase frequency count for each digit found
        for (int i = 0; i < count; i++)
        {
            frequency[digits[i]]++;
        }

        // Display the frequency of each digit
        Console.WriteLine("\nDigit Frequency:");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i] > 0)
            {
                Console.WriteLine("Digit " + i + " occurs " + frequency[i] + " times");
            }
        }
    }
}
