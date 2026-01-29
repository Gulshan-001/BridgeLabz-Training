using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        Dictionary<string, List<string>> recordMap =
            new Dictionary<string, List<string>>();

        // Skip header
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] data = line.Split(',');

            string id = data[0];

            if (!recordMap.ContainsKey(id))
            {
                recordMap[id] = new List<string>();
            }

            recordMap[id].Add(line);
        }

        Console.WriteLine("Duplicate Records");
        Console.WriteLine("------------------");

        bool foundDuplicate = false;

        foreach (var entry in recordMap)
        {
            if (entry.Value.Count > 1)
            {
                foundDuplicate = true;

                foreach (string record in entry.Value)
                {
                    Console.WriteLine(record);
                }

                Console.WriteLine();
            }
        }

        if (!foundDuplicate)
        {
            Console.WriteLine("No duplicate records found.");
        }
    }
}
