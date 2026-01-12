using System;
using System.IO;

class WorkCount
{
    static void Main()
    {
        Console.Write("Enter file path: ");
        string filePath = Console.ReadLine();

        Console.Write("Enter word to search: ");
        string searchWord = Console.ReadLine();

        int count = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(
                    new char[] { ' ', '.', ',', '!', '?', ';', ':' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                foreach (string word in words)
                {
                    if (word.Equals(searchWord, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }
            }
        }

        Console.WriteLine($"The word \"{searchWord}\" appears {count} times.");
    }
}
