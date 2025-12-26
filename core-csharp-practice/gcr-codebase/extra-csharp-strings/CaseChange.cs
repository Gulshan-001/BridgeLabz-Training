using System;

class CaseChange
{
    static void Main()
    {
        // Input a string from the user
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string result = "";

        // Loop through each character and toggle case
        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (ch >= 'a' && ch <= 'z')
                result += (char)(ch - 32); // Convert lowercase to uppercase
            else if (ch >= 'A' && ch <= 'Z')
                result += (char)(ch + 32); // Convert uppercase to lowercase
            else
                result += ch; // Keep non-alphabet characters unchanged
        }

        // Output the toggled string
        Console.WriteLine("Toggled string: " + result);
    }
}
