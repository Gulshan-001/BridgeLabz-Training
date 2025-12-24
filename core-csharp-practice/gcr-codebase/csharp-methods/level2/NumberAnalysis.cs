using System;

class NumberAnalysis
{
    // method to check whether number is positive or negative
    static bool IsPositive(int number)
    {
        return number >= 0;
    }

    // method to check whether number is even or odd
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // method to compare two numbers
    // returns 1 if number1 > number2, 0 if equal, -1 if number1 < number2
    static int Compare(int number1, int number2)
    {
        if (number1 > number2)
            return 1;
        else if (number1 < number2)
            return -1;
        else
            return 0;
    }

    static void Main(string[] args)
    {
        int[] numbers = new int[5];

        // take 5 numbers from user
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number " + (i + 1) + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        // check each number for positive/negative and even/odd
        for (int i = 0; i < numbers.Length; i++)
        {
            if (IsPositive(numbers[i]))
            {
                if (IsEven(numbers[i]))
                    Console.WriteLine(numbers[i] + " is positive and even.");
                else
                    Console.WriteLine(numbers[i] + " is positive and odd.");
            }
            else
            {
                Console.WriteLine(numbers[i] + " is negative.");
            }
        }

        // compare first and last elements of the array
        int comparisonResult = Compare(numbers[0], numbers[numbers.Length - 1]);

        if (comparisonResult == 1)
            Console.WriteLine("First element is greater than last element.");
        else if (comparisonResult == -1)
            Console.WriteLine("First element is less than last element.");
        else
            Console.WriteLine("First and last elements are equal.");
    }
}
