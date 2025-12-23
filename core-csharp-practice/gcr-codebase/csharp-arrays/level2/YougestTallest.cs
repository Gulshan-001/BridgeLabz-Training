using System;

class YoungestTallest
{
    static void Main(string[] args)
    {
        // Names of the friends
        string[] names = { "Amar", "Akbar", "Anthony" };

        // Arrays to store ages and heights
        int[] ages = new int[3];
        double[] heights = new double[3];

        // Taking input from the user
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine("Enter details for " + names[i]);

            Console.Write("Age: ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Height: ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        // Assume first friend is youngest and tallest initially
        int youngestIndex = 0;
        int tallestIndex = 0;

        // Finding youngest and tallest friend
        for (int i = 1; i < names.Length; i++)
        {
            if (ages[i] < ages[youngestIndex])
            {
                youngestIndex = i;
            }

            if (heights[i] > heights[tallestIndex])
            {
                tallestIndex = i;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Youngest friend is: " + names[youngestIndex]);
        Console.WriteLine("Tallest friend is: " + names[tallestIndex]);
    }
}
