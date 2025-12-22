using System;

class PowerOfNumber
{
    static void Main()
    {
        Console.WriteLine("Enter the number:");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the power:");
        int power = Convert.ToInt32(Console.ReadLine());

        int result = 1;

        for (int i = 1; i <= power; i++)
        {
            result = result * number;
        }

        Console.WriteLine(number + " raised to the power " + power + " is " + result);
    }
}
