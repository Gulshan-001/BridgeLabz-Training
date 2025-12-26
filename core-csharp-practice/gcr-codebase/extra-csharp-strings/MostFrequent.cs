using System;

class MostFrequentChar
{
    static void Main()
    {
        // Input string from the user
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        int maxCount = 0;
        char mostFrequent = ' ';

        // Loop through each character to count frequency
        for (int i = 0; i < input.Length; i++)
        {
            int count = 0;

            for (int j = 0; j < input.Length; j++)
            {
                if (input[i] == input[j])
                    count++;
            }

            if (count > maxCount)
            {
                maxCount = count;
                mostFrequent = input[i];
            }
        }

        // Output the most frequent character
        Console.WriteLine("Most Frequent Character: '" + mostFrequent + "'");
    }
}
