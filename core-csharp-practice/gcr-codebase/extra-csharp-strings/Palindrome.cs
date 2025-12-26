using System;

class Palindrome
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        // Convert to lowercase to ignore case
        string lowerInput = input.ToLower();

        // Reverse the string using built-in methods
        char[] chars = lowerInput.ToCharArray();
        Array.Reverse(chars);
        string reversed = new string(chars);

        // Check if original and reversed strings are the same
        if (lowerInput == reversed)
        {
            Console.WriteLine("The string is a palindrome.");
        }
        else
        {
            Console.WriteLine("The string is not a palindrome.");
        }
    }
}
