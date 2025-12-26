using System;

class TraverseWithoutBuiltIn
{
    // Method to return characters without using ToCharArray()
    static char[] GetCharactersWithoutToCharArray(string str)
    {
        char[] chars = new char[str.Length];

        for (int i = 0; i < str.Length; i++)
        {
            chars[i] = str[i]; // charAt logic
        }

        return chars;
    }

    // Method to display character array
    static void DisplayCharArray(char[] arr)
    {
        foreach (char c in arr)
        {
            Console.Write(c + " ");
        }
        Console.WriteLine();
    }

    // Method to compare two character arrays
    static bool CompareCharArrays(char[] arr1, char[] arr2)
    {
        if (arr1.Length != arr2.Length)
            return false;

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
                return false;
        }

        return true;
    }
    static void Main()
    {
        // Take user input
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        // Custom method without using ToCharArray()
        char[] customChars = GetCharactersWithoutToCharArray(input);

        // Built-in method
        char[] builtInChars = input.ToCharArray();

        // Display results
        Console.WriteLine("\nCharacters using custom method:");
        DisplayCharArray(customChars);

        Console.WriteLine("\nCharacters using ToCharArray():");
        DisplayCharArray(builtInChars);

        // Compare results
        Console.WriteLine("\nAre both character arrays equal? " +
                          CompareCharArrays(customChars, builtInChars));
    }
}
