using System;

class Upper
{
    // Convert string to uppercase using ASCII logic
    static string toUpperManually(string text)
    {
        char[] result = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];

            // ASCII: a–z = 97–122, A–Z = 65–90
            if (ch >= 'a' && ch <= 'z')
            {
                ch = (char)(ch - 32);
            }

            result[i] = ch;
        }

        return new string(result);
    }

    static void Main()
    {
        Console.Write("Enter text: ");
        string input = Console.ReadLine();

        string manualUpper = toUpperManually(input);
        string builtInUpper = input.ToUpper();

        Console.WriteLine("Manual Uppercase : " + manualUpper);
        Console.WriteLine("Built-in Uppercase: " + builtInUpper);
    }
}
