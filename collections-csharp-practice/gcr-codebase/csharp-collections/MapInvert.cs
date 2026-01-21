using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> input = new Dictionary<string, int>
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 1 }
        };

        Dictionary<int, List<string>> inverted = InvertMap(input);

        Console.WriteLine("Inverted Map:");
        PrintInvertedMap(inverted);
    }

    // ================= INVERT MAP LOGIC =================
    static Dictionary<V, List<K>> InvertMap<K, V>(Dictionary<K, V> map)
    {
        Dictionary<V, List<K>> inverted = new Dictionary<V, List<K>>();

        foreach (var pair in map)
        {
            // If value is not already a key, create a new list
            if (!inverted.ContainsKey(pair.Value))
            {
                inverted[pair.Value] = new List<K>();
            }

            // Add original key to the list
            inverted[pair.Value].Add(pair.Key);
        }

        return inverted;
    }

    // ================= PRINT METHOD =================
    static void PrintInvertedMap<V, K>(Dictionary<V, List<K>> map)
    {
        foreach (var pair in map)
        {
            Console.Write($"{pair.Key} = [");

            for (int i = 0; i < pair.Value.Count; i++)
            {
                Console.Write(pair.Value[i]);
                if (i < pair.Value.Count - 1)
                    Console.Write(", ");
            }

            Console.WriteLine("]");
        }
    }
}
