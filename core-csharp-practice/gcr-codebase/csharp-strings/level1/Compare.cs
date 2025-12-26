using System;

class Compare
{
    // Method to compare strings using char-by-char logic
    static bool CompareStringsCharByChar(string s1, string s2)
    {
        // If lengths are different, strings cannot be equal
        if (s1.Length != s2.Length)
            return false;

        // Compare each character
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
                return false;
        }

        // All characters matched
        return true;
    }
    static void Main()
    {
        // Take user input
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        // Custom comparison using charAt logic
        bool customResult = CompareStringsCharByChar(str1, str2);

        // Built-in comparison
        bool builtInResult = str1.Equals(str2);

        // Display results
        Console.WriteLine("\nCustom Comparison Result: " + customResult);
        Console.WriteLine("Built-in Equals() Result: " + builtInResult);
    }
}
