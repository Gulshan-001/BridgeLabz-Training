using System;

class YoungestTallest
{
    // method to find the youngest friend
    static int FindYoungest(int[] ages)
    {
        int minIndex = 0;

        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < ages[minIndex])
                minIndex = i;
        }

        return minIndex;
    }

    // method to find the tallest friend
    static int FindTallest(double[] heights)
    {
        int maxIndex = 0;

        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > heights[maxIndex])
                maxIndex = i;
        }

        return maxIndex;
    }

    static void Main(string[] args)
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];

        // take age and height inputs for each friend
        for (int i = 0; i < names.Length; i++)
        {
            Console.Write("Enter age of " + names[i] + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter height of " + names[i] + ": ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        int youngestIndex = FindYoungest(ages);
        int tallestIndex = FindTallest(heights);

        Console.WriteLine("Youngest friend is: " + names[youngestIndex]);
        Console.WriteLine("Tallest friend is: " + names[tallestIndex]);
    }
}
