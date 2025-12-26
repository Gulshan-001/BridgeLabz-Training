using System;

class SubstringFrequency
{
    static void Main()
    {
        // Input main string and substring from the user
        Console.Write("Enter the main string: ");
        string text = Console.ReadLine();

        Console.Write("Enter the substring to search: ");
        string sub = Console.ReadLine();

        int count = 0;

        // Loop through the string to check for substring matches
        for (int i = 0; i <= text.Length - sub.Length; i++)
        {
            if (text.Substring(i, sub.Length) == sub)
                count++;
        }

        // Output the number of occurrences
        Console.WriteLine("The substring occurs " + count + " times.");
    }
}
