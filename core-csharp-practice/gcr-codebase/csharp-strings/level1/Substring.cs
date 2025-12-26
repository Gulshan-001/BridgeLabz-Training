using System;

class SubstringCreator
{
     // Method to create substring using charAt logic
    static string CreateSubstringUsingCharAt(string str, int start, int end)
    {
        string result = "";

        for (int i = start; i < end; i++)
        {
            result += str[i]; // charAt logic
        }

        return result;
    }
    static void Main()
    {
        // Take user input
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        Console.Write("Enter start index: ");
        int startIndex = int.Parse(Console.ReadLine());

        Console.Write("Enter end index: ");
        int endIndex = int.Parse(Console.ReadLine());

        // Create substring using charAt logic
        string customSubstring = CreateSubstringUsingCharAt(input, startIndex, endIndex);

        // Create substring using built-in method
        string builtInSubstring = input.Substring(startIndex, endIndex - startIndex);

        // Display results
        Console.WriteLine("\nCustom Substring: " + customSubstring);
        Console.WriteLine("Built-in Substring: " + builtInSubstring);

        // Compare results
        Console.WriteLine("\nAre both substrings equal? " + 
                          customSubstring.Equals(builtInSubstring));
    }
}
