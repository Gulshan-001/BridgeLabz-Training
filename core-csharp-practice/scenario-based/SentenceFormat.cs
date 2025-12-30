using System;
using System.Text;

class SentenceFormat
{
    static void Main()
    {
        Console.WriteLine("Enter a paragraph:");
        string text = Console.ReadLine() ?? "";

        // Stop early if there is nothing to work with
        if (text.Length == 0)
        {
            Console.WriteLine("Empty input");
            return;
        }

        // Builders used throughout the program
        StringBuilder formattedText = new StringBuilder();
        StringBuilder tempWord = new StringBuilder();
        StringBuilder longestWord = new StringBuilder();

        // Counters and trackers
        int wordCount = 0;
        int currentWordLength = 0;
        int maxWordLength = 0;

        // Handle the first character separately to simplify the loop
        char firstChar = text[0];

        // Capitalize first character if required
        if (firstChar >= 'a' && firstChar <= 'z')
            firstChar = (char)(firstChar - 32);

        formattedText.Append(firstChar);

        // If the paragraph doesn’t start with space, first word already exists
        if (firstChar != ' ')
            wordCount = 1;

        tempWord.Append(firstChar);
        currentWordLength = 1;

        // Process remaining characters one by one
        for (int i = 1; i < text.Length; i++)
        {
            char currentChar = text[i];
            char previousChar = text[i - 1];

            // Ignore extra spaces to avoid uneven spacing
            if (currentChar == ' ' && previousChar == ' ')
                continue;

            // Automatically add a space after punctuation
            if (currentChar != ' ' &&
                (previousChar == '.' || previousChar == '!' ||
                 previousChar == '?' || previousChar == ','))
            {
                formattedText.Append(' ');
            }

            // Capitalize first letter of a new sentence
            if (i >= 2 && previousChar == ' ' &&
                (text[i - 2] == '.' || text[i - 2] == '!' || text[i - 2] == '?'))
            {
                if (currentChar >= 'a' && currentChar <= 'z')
                    currentChar = (char)(currentChar - 32);
            }

            formattedText.Append(currentChar);

            // Increase word count when a word starts
            if (previousChar == ' ' && currentChar != ' ')
                wordCount++;

            // Build the word character by character
            if ((currentChar >= 'a' && currentChar <= 'z') ||
                (currentChar >= 'A' && currentChar <= 'Z'))
            {
                tempWord.Append(currentChar);
                currentWordLength++;
            }
            else
            {
                // Compare word length once a non-letter is found
                if (currentWordLength > maxWordLength)
                {
                    maxWordLength = currentWordLength;
                    longestWord.Clear();
                    longestWord.Append(tempWord);
                }

                // Reset for the next word
                tempWord.Clear();
                currentWordLength = 0;
            }
        }

        // Final check for the last word in the paragraph
        if (currentWordLength > maxWordLength)
        {
            longestWord.Clear();
            longestWord.Append(tempWord);
        }

        Console.WriteLine("\nFormatted Text:");
        Console.WriteLine(formattedText.ToString());

        Console.WriteLine("\nWord Count: " + wordCount);
        Console.WriteLine("Longest Word: " + longestWord.ToString());

        // Word replacement input
        Console.WriteLine("\nEnter word to replace:");
        string oldWord = Console.ReadLine() ?? "";

        Console.WriteLine("Enter replacement word:");
        string newWord = Console.ReadLine() ?? "";

        Console.WriteLine("\nAfter Replacement:");
        Console.WriteLine(ReplaceWord(formattedText.ToString(), oldWord, newWord));
    }

    // Replaces a word without considering case sensitivity
    static string ReplaceWord(string text, string oldWord, string newWord)
    {
        StringBuilder result = new StringBuilder();
        StringBuilder buffer = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];

            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
            {
                buffer.Append(ch);
            }
            else
            {
                if (buffer.Length > 0)
                {
                    if (IsSameWord(buffer, oldWord))
                        result.Append(newWord);
                    else
                        result.Append(buffer);

                    buffer.Clear();
                }
                result.Append(ch);
            }
        }

        // Handle leftover word at the end
        if (buffer.Length > 0)
        {
            if (IsSameWord(buffer, oldWord))
                result.Append(newWord);
            else
                result.Append(buffer);
        }

        return result.ToString();
    }

    // Compares two words ignoring letter case
    static bool IsSameWord(StringBuilder word, string target)
    {
        if (word.Length != target.Length)
            return false;

        for (int i = 0; i < word.Length; i++)
        {
            char a = word[i];
            char b = target[i];

            if (a >= 'A' && a <= 'Z') a = (char)(a + 32);
            if (b >= 'A' && b <= 'Z') b = (char)(b + 32);

            if (a != b)
                return false;
        }
        return true;
    }
}
