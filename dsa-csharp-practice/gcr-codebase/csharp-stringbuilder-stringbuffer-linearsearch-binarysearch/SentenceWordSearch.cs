using System;

class SentenceWordSearch
{
    static void Main()
    {
        string[] sentences =
        {
            "C# is a powerful language",
            "Java is also popular",
            "Learning C# is fun",
            "Programming requires practice"
        };

        Console.Write("Enter word to search: ");
        string searchWord = Console.ReadLine();

        int foundIndex = -1;

        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].IndexOf(searchWord, StringComparison.OrdinalIgnoreCase) != -1)
            {
                foundIndex = i;
                break; // Stop at first match
            }
        }

        if (foundIndex != -1)
        {
            Console.WriteLine("Word found in sentence:");
            Console.WriteLine(sentences[foundIndex]);
        }
        else
        {
            Console.WriteLine("Word not found in any sentence.");
        }
    }
}
