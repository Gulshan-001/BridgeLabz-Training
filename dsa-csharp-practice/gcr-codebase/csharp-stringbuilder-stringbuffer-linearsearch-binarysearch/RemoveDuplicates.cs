using System;
using System.Text;

class RemoveDuplicates
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            // Check if character already exists in result
            if (result.ToString().IndexOf(currentChar) == -1)
            {
                result.Append(currentChar);
            }
        }

        Console.WriteLine("String after removing duplicates: " + result.ToString());
    }
}
