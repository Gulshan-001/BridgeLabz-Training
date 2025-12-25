using System;

class NumberChecker
{
    // method to find count of digits in a number
    static int CountDigits(int number)
    {
        int count = 0;
        number = Math.Abs(number);

        while (number > 0)
        {
            count++;
            number /= 10;
        }

        return count;
    }

    // method to store digits of number into an array
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

    // method to check if number is a duck number
    static bool IsDuckNumber(int[] digits)
    {
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] != 0)
                return true;
        }
        return false;
    }

    // method to check if number is an Armstrong number
    static bool IsArmstrongNumber(int number, int[] digits)
    {
        int power = digits.Length;
        int sum = 0;

        for (int i = 0; i < digits.Length; i++)
        {
            sum += (int)Math.Pow(digits[i], power);
        }

        return sum == number;
    }

    // method to find largest and second largest digit
    static int[] FindLargestAndSecondLargest(int[] digits)
    {
        int largest = Int32.MinValue;
        int secondLargest = Int32.MinValue;

        for (int i = 0; i < digits.Length; i++)
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

        return new int[] { largest, secondLargest };
    }

    static void Main(string[] args)
    {
        // take number input from user
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int digitCount = CountDigits(number);
        int[] digits = GetDigitsArray(number);

        Console.WriteLine("Count of digits: " + digitCount);

        Console.WriteLine("Digits:");
        for (int i = 0; i < digits.Length; i++)
        {
            Console.Write(digits[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Duck Number: " + (IsDuckNumber(digits) ? "Yes" : "No"));
        Console.WriteLine("Armstrong Number: " + (IsArmstrongNumber(number, digits) ? "Yes" : "No"));

        int[] largestValues = FindLargestAndSecondLargest(digits);
        Console.WriteLine("Largest digit: " + largestValues[0]);
        Console.WriteLine("Second largest digit: " + largestValues[1]);
    }
}
