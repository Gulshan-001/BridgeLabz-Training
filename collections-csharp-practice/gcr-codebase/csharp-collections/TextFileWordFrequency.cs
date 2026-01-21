using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Simulating file content (can be replaced with File.ReadAllText)
        string text = "Hello world, hello Java!";

        Dictionary<string, int> wordFrequency = CountWordFrequency(text);

        Console.WriteLine("Word Frequency:");
        PrintDictionary(wordFrequency);
    }

    // ================= WORD FREQUENCY LOGIC =================
    static Dictionary<string, int> CountWordFrequency(string text)
    {
        Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

        // Convert to lowercase to make counting case-insensitive
        text = text.ToLower();

        // Remove punctuation using regex
        text = Regex.Replace(text, @"[^\w\s]", "");

        // Split text into words
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            // Increase count if word already exists
            if (frequencyMap.ContainsKey(word))
            {
                frequencyMap[word]++;
            }
            else
            {
                frequencyMap[word] = 1;
            }
        }

        return frequencyMap;
    }

    // ================= PRINT METHOD =================
    static void PrintDictionary(Dictionary<string, int> map)
    {
        Console.Write("{ ");
        bool first = true;

        foreach (var pair in map)
        {
            if (!first) Console.Write(", ");
            Console.Write($"\"{pair.Key}\": {pair.Value}");
            first = false;
        }

        Console.WriteLine(" }");
    }
}
