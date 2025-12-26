using System;

class DuplicatesRemove
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string result = "";

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            // Add the character only if it is not already in the result
            if (!result.Contains(ch))
            {
                result += ch;
            }
        }

        Console.WriteLine("String after removing duplicates: " + result);
    }
}
