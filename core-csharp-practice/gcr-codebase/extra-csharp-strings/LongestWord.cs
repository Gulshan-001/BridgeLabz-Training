using System;

class LongestWord
{
    static void Main()
    {
        // Input sentence
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();

        string longestWord = "";
        string currentWord = "";

        // Build words and find the longest
        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] != ' ')
                currentWord += sentence[i];
            else
            {
                if (currentWord.Length > longestWord.Length)
                    longestWord = currentWord;
                currentWord = "";
            }
        }

        if (currentWord.Length > longestWord.Length)
            longestWord = currentWord;

        // Output result
        Console.WriteLine("The longest word is: " + longestWord);
    }
}
