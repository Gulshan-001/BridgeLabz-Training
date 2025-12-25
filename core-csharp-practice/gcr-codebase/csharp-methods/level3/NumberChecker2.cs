using System;

class NumberChecker2
{
    // method to find count of digits in a number
    static int CountDigits(int number)
    {
        number = Math.Abs(number);
        int count = 0;

        while (number > 0)
        {
            count++;
            number /= 10;
        }

        return count;
    }

    // method to store digits of the number in an array
    static int[] GetDigitsArray(int number)
    {
        number = Math.Abs(number);
        int count = CountDigits(number);
        int[] digits = new int[count];

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = number % 10;
            number /= 10;
        }

        return digits;
    }

    // method to find sum of digits
    static int SumOfDigits(int[] digits)
    {
        int sum = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            sum += digits[i];
        }
        return sum;
    }

    // method to find sum of squares of digits
    static double SumOfSquaresOfDigits(int[] digits)
    {
        double sum = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            sum += Math.Pow(digits[i], 2);
        }
        return sum;
    }

    // method to check if number is a Harshad number
    static bool IsHarshadNumber(int number, int[] digits)
    {
        int sum = SumOfDigits(digits);
        return sum != 0 && number % sum == 0;
    }

    // method to find frequency of each digit
    static int[,] FindDigitFrequency(int[] digits)
    {
        int[,] frequency = new int[10, 2];

        for (int i = 0; i < 10; i++)
        {
            frequency[i, 0] = i;
            frequency[i, 1] = 0;
        }

        for (int i = 0; i < digits.Length; i++)
        {
            frequency[digits[i], 1]++;
        }

        return frequency;
    }

    static void Main(string[] args)
    {
        // take number input from user
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigitsArray(number);

        Console.WriteLine("Count of digits: " + CountDigits(number));
        Console.WriteLine("Sum of digits: " + SumOfDigits(digits));
        Console.WriteLine("Sum of squares of digits: " + SumOfSquaresOfDigits(digits));
        Console.WriteLine("Harshad Number: " + (IsHarshadNumber(number, digits) ? "Yes" : "No"));

        int[,] frequency = FindDigitFrequency(digits);

        Console.WriteLine("Digit Frequency:");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i, 1] > 0)
                Console.WriteLine("Digit " + frequency[i, 0] + " occurs " + frequency[i, 1] + " times");
        }
    }
}
