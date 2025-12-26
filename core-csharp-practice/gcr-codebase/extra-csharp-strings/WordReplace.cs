using System;

class WordReplace
{
    static void Main()
    {
        // Input sentence and the words to replace
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();

        Console.Write("Enter the word to replace: ");
        string oldWord = Console.ReadLine();

        Console.Write("Enter the new word: ");
        string newWord = Console.ReadLine();

        // Replace the old word with the new word
        string modifiedSentence = sentence.Replace(oldWord, newWord);

        // Output the modified sentence
        Console.WriteLine("Modified Sentence: " + modifiedSentence);
    }
}
