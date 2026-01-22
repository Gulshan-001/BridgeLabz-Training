using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "input.txt";

        // Check file existence manually
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        // Read file line by line
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                // Convert to lowercase for case-insensitive counting
                line = line.ToLower();

                // Split words using common delimiters
                string[] words = line.Split(
                    new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '"', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                foreach (string word in words)
                {
                    if (wordCount.ContainsKey(word))
                        wordCount[word]++;
                    else
                        wordCount[word] = 1;
                }
            }
        }

        // Sort words by frequency (descending) and take top 5
        var topWords = wordCount
            .OrderByDescending(pair => pair.Value)
            .Take(5);

        Console.WriteLine("Top 5 Most Frequent Words:");
        foreach (var pair in topWords)
        {
            Console.WriteLine($"{pair.Key} → {pair.Value}");
        }
    }
}
