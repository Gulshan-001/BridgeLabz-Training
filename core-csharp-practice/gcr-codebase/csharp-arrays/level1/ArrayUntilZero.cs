using System;

class ArrayUntilZero
{
    static void Main(string[] args)
    {
        // Array to store up to 10 numbers
        double[] numbers = new double[10];

        // Variable to store the total sum
        double total = 0.0;

        // Index to keep track of how many values are stored
        int index = 0;

        Console.WriteLine("Enter numbers (0 or negative number to stop):");

        // Infinite loop to keep taking input
        while (true)
        {
            // Stop if array limit is reached
            if (index == 10)
            {
                break;
            }

            // Take user input
            double value = Convert.ToDouble(Console.ReadLine());

            // Stop if user enters 0 or a negative number
            if (value <= 0)
            {
                break;
            }

            // Store value in array and move to next index
            numbers[index] = value;
            index++;
        }

        Console.WriteLine();
        Console.WriteLine("Numbers entered:");

        // Loop to display values and calculate total
        for (int i = 0; i < index; i++)
        {
            Console.WriteLine(numbers[i]);
            total += numbers[i];
        }

        Console.WriteLine();
        Console.WriteLine("The sum of all numbers is: " + total);
    }
}
