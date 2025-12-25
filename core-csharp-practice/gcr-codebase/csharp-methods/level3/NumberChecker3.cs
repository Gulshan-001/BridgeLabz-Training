using System;

class NumberChecker3
{
    // Method to find count of digits
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

    // Method to store digits in an array
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

    // Method to reverse digits array
    static int[] ReverseArray(int[] digits)
    {
        int[] reversed = new int[digits.Length];
        int index = 0;

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            reversed[index++] = digits[i];
        }

        return reversed;
    }

    // Method to compare two arrays
    static bool AreArraysEqual(int[] arr1, int[] arr2)
    {
        if (arr1.Length != arr2.Length)
            return false;

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
                return false;
        }

        return true;
    }

    // Method to check palindrome number
    static bool IsPalindrome(int[] digits)
    {
        int[] reversed = ReverseArray(digits);
        return AreArraysEqual(digits, reversed);
    }

    // Method to check duck number
    // Duck number has at least one non-zero digit (excluding leading zeros)
    static bool IsDuckNumber(int[] digits)
    {
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] != 0)
                return true;
        }
        return false;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigitsArray(number);

        Console.WriteLine("Count of digits: " + CountDigits(number));

        Console.Write("Digits: ");
        foreach (int d in digits)
            Console.Write(d + " ");
        Console.WriteLine();

        int[] reversed = ReverseArray(digits);
        Console.Write("Reversed Digits: ");
        foreach (int d in reversed)
            Console.Write(d + " ");
        Console.WriteLine();

        Console.WriteLine("Palindrome Number: " + (IsPalindrome(digits) ? "Yes" : "No"));
        Console.WriteLine("Duck Number: " + (IsDuckNumber(digits) ? "Yes" : "No"));
    }
}
