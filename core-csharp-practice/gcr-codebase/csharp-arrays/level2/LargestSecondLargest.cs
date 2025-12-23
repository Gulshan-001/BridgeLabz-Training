using System;

class LargestSecondLargest
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int index = 0;

        // Storing digits of the number in the array
        while (number != 0)
        {
            // Stop if array size limit is reached
            if (index == maxDigit)
            {
                break;
            }

            digits[index] = number % 10;
            number = number / 10;
            index++;
        }

        int largest = 0;
        int secondLargest = 0;

        // Finding largest and second largest digit
        for (int i = 0; i < index; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i];
            }
        }

        Console.WriteLine();
        Console.WriteLine("Largest digit is: " + largest);
        Console.WriteLine("Second largest digit is: " + secondLargest);
    }
}
