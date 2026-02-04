using System;
using System.Collections.Generic;
using System.Text;

public class LexicalService : ILexicalService
{
    public void ProcessWords(string word1, string word2)
    {
        if (!WordValidator.IsValidWord(word1))
        {
            Console.WriteLine(word1 + " is an invalid word");
            return;
        }

        if (!WordValidator.IsValidWord(word2))
        {
            Console.WriteLine(word2 + " is an invalid word");
            return;
        }

        if (IsReverse(word1, word2))
        {
            string reversed = Reverse(word1).ToLower();
            Console.WriteLine(ReplaceVowels(reversed));
        }
        else
        {
            string combined = (word1 + word2).ToUpper();
            HandleCounts(combined);
        }
    }

    private bool IsReverse(string w1, string w2)
    {
        return Reverse(w1).Equals(w2, StringComparison.OrdinalIgnoreCase);
    }

    private string Reverse(string word)
    {
        char[] arr = word.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    private string ReplaceVowels(string word)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in word)
        {
            if ("aeiou".Contains(c))
                sb.Append('@');
            else
                sb.Append(c);
        }

        return sb.ToString();
    }

    private void HandleCounts(string word)
    {
        int vowels = 0, consonants = 0;
        HashSet<char> vowelSet = new HashSet<char>();
        HashSet<char> consonantSet = new HashSet<char>();

        foreach (char c in word)
        {
            if ("AEIOU".Contains(c))
            {
                vowels++;
                vowelSet.Add(c);
            }
            else if (char.IsLetter(c))
            {
                consonants++;
                consonantSet.Add(c);
            }
        }

        if (vowels > consonants)
        {
            PrintFirstTwo(vowelSet);
        }
        else if (consonants > vowels)
        {
            PrintFirstTwo(consonantSet);
        }
        else
        {
            Console.WriteLine("Vowels and consonants are equal");
        }
    }

    private void PrintFirstTwo(HashSet<char> set)
    {
        int count = 0;
        foreach (char c in set)
        {
            Console.Write(c);
            count++;
            if (count == 2)
                break;
        }
        Console.WriteLine();
    }
}
