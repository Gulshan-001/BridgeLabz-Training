using System;

class MeanHeight
{
    static void Main(string[] args)
    {
        // Array to store heights of 11 players
        double[] heights = new double[11];
        double sum = 0.0;

        Console.WriteLine("Enter the height of 11 football players:");

        // Taking height input and adding to sum
        for (int i = 0; i < heights.Length; i++)
        {
            Console.Write("Enter height of player " + (i + 1) + ": ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
            sum += heights[i];
        }

        // Calculating mean height
        double mean = sum / heights.Length;

        Console.WriteLine();
        Console.WriteLine("The mean height of the football team is: " + mean);
    }
}
