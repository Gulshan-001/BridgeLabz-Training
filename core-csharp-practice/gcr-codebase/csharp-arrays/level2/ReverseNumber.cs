using System;

class ReverseNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        int temp = number;
        int count = 0;

        while (temp != 0)
        {
            count++;
            temp /= 10;
        }

        int[] digits = new int[count];
        temp = number;

        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }

        int[] reverse = new int[count];

        for (int i = 0; i < count; i++)
        {
            reverse[i] = digits[count - 1 - i];
        }

        Console.WriteLine("Reversed number:");
        for (int i = 0; i < count; i++)
        {
            Console.Write(reverse[i]);
        }
    }
}
