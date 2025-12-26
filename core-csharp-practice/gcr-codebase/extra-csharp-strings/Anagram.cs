using System;

class Anagram
{
    static void Main()
    {
        // Input two strings from the user
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        // Remove spaces and convert to lowercase for uniform comparison
        str1 = str1.Replace(" ", "").ToLower();
        str2 = str2.Replace(" ", "").ToLower();

        // If lengths are different, they cannot be anagrams
        if (str1.Length != str2.Length)
        {
            Console.WriteLine("The strings are not anagrams.");
            return;
        }

        // Count frequency of each character in both strings
        int[] freq1 = new int[256]; // ASCII character frequency
        int[] freq2 = new int[256];

        for (int i = 0; i < str1.Length; i++)
        {
            freq1[str1[i]]++;
            freq2[str2[i]]++;
        }

        // Compare the frequency arrays
        bool isAnagram = true;
        for (int i = 0; i < 256; i++)
        {
            if (freq1[i] != freq2[i])
            {
                isAnagram = false;
                break;
            }
        }

        // Output the result
        if (isAnagram)
            Console.WriteLine("The strings are anagrams.");
        else
            Console.WriteLine("The strings are not anagrams.");
    }
}
