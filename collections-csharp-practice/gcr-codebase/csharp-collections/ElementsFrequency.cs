using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] input = { "apple", "banana", "apple", "orange" };

        Dictionary<string, int> frequencyMap = FindFrequency(input);

        Console.WriteLine("Element Frequency:");
        PrintDictionary(frequencyMap);
    }

    // ================= FREQUENCY LOGIC =================
    static Dictionary<string, int> FindFrequency(string[] items)
    {
        Dictionary<string, int> map = new Dictionary<string, int>();

        foreach (string item in items)
        {
            // If item already exists, increase its count
            if (map.ContainsKey(item))
            {
                map[item]++;
            }
            else
            {
                // First time seeing this item
                map[item] = 1;
            }
        }

        return map;
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
