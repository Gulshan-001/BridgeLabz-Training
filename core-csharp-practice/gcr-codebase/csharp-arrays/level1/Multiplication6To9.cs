using System;

class Multiplication6To9
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        // Array to store multiplication results from 6 to 9
        int[] multiplicationResult = new int[4];

        // Calculating multiplication table from 6 to 9
        int index = 0;
        for (int i = 6; i <= 9; i++)
        {
            multiplicationResult[index] = number * i;
            index++;
        }

        Console.WriteLine();
        Console.WriteLine("Multiplication Table from 6 to 9:");

        // Displaying results from the array
        index = 0;
        for (int i = 6; i <= 9; i++)
        {
            Console.WriteLine(number + " * " + i + " = " + multiplicationResult[index]);
            index++;
        }
    }
}
