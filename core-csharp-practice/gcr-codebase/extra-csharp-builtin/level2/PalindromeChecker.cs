using System;

class PalindromeChecker
{
    static string GetInput()
    {
        Console.Write("Enter a string: ");
        return Console.ReadLine();
    }

    static bool IsPalindrome(string text)
    {
        int start = 0;
        int end = text.Length - 1;

        while (start < end)
        {
            if (text[start] != text[end])
                return false;

            start++;
            end--;
        }

        return true;
    }

    static void Main()
    {
        // Take input from the user
        string input = GetInput();

        // Check and display result
        if (IsPalindrome(input))
            Console.WriteLine("The string is a palindrome.");
        else
            Console.WriteLine("The string is not a palindrome.");
    }
}
