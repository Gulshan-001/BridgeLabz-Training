using System;

class SumCompareFor
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number:");
        int number1 = Convert.ToInt32(Console.ReadLine());

        int originalNumber = number1; // store original value
        int sum = 0;

        for (int i = number1; i > 0; i--)
        {
            sum = sum + i;
        }

        int sum2 = originalNumber * (originalNumber + 1) / 2;

        if (sum == sum2)
        {
            Console.WriteLine("The sums are equal");
        }
        else
        {
            Console.WriteLine("The sums are not equal");
        }
    }
}
