using System;

class Lower
{
    // Convert string to lowercase using ASCII logic
    static string toLowerManually(string text)
    {
        char[] result = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];

            // ASCII: A–Z = 65–90, a–z = 97–122
            if (ch >= 'A' && ch <= 'Z')
            {
                ch = (char)(ch + 32);
            }

            result[i] = ch;
        }

        return new string(result);
    }

    static void Main()
    {
        Console.Write("Enter text: ");
        string input = Console.ReadLine();

        string manualLower = toLowerManually(input);
        string builtInLower = input.ToLower();

        Console.WriteLine("Manual Lowercase : " + manualLower);
        Console.WriteLine("Built-in Lowercase: " + builtInLower);
    }
}
