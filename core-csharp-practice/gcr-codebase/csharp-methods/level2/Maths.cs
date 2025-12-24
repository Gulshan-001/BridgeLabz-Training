using System;

class Maths
{
    // method to generate array of 4-digit random numbers
    static int[] Generate4DigitRandomArray(int size)
    {
        int[] numbers = new int[size];
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            numbers[i] = random.Next(1000, 10000); // generates 4 digit number
        }

        return numbers;
    }

    // method to find average, minimum and maximum of the array
    static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            min = Math.Min(min, numbers[i]);
            max = Math.Max(max, numbers[i]);
        }

        double average = (double)sum / numbers.Length;
        return new double[] { average, min, max };
    }

    static void Main(string[] args)
    {
        // generate 5 random 4-digit numbers
        int[] numbers = Generate4DigitRandomArray(5);

        Console.WriteLine("Generated Numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        // find average, min and max
        double[] result = FindAverageMinMax(numbers);

        Console.WriteLine("Average: " + result[0]);
        Console.WriteLine("Minimum: " + result[1]);
        Console.WriteLine("Maximum: " + result[2]);
    }
}
