using System;

class ArrayNeagativeSearch  
{
    static void Main()
    {
        int[] numbers = { 5, 10, 3, -4, 8, -2 };

        int firstNegative = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < 0)
            {
                firstNegative = numbers[i];
                break; // Stop at first negative number
            }
        }

        if (firstNegative != -1)
        {
            Console.WriteLine("First negative number: " + firstNegative);
        }
        else
        {
            Console.WriteLine("No negative number found in the array.");
        }
    }
}
