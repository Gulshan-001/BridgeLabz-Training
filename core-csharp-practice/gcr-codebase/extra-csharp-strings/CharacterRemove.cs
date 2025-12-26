using System;

class RemoveCharacter
{
    static void Main()
    {
        // Input string and character to remove
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        Console.Write("Enter the character to remove: ");
        char toRemove = Console.ReadLine()[0];

        string result = "";

        // Loop through the string and build a new string without the character
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != toRemove)
                result += input[i];
        }

        // Output the modified string
        Console.WriteLine("Modified String: " + result);
    }
}
