using System;

class MultiplicationTable
{
    static void Main(string[] args)
    {
        // Ask the user for a number
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        // Array to store multiplication results from 1 to 10
        int[] table = new int[10];

        // Calculating the multiplication table and storing it in the array
        for (int i = 1; i <= 10; i++)
        {
            table[i - 1] = number * i;
        }

        Console.WriteLine();
        Console.WriteLine("Multiplication Table:");
        Console.WriteLine();

        // Printing the multiplication table from the array
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(number + " * " + i + " = " + table[i - 1]);
        }
    }
}
