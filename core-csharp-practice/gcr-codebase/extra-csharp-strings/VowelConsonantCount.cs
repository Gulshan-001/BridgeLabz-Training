using System;

class VowelConsonantCount
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        int vowels = 0;
        int consonants = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            // Consider only letters
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
            {
                // Check for vowels
                if (ch == 'a' || ch == 'e' || ch == 'i' ||
                    ch == 'o' || ch == 'u' ||
                    ch == 'A' || ch == 'E' || ch == 'I' ||
                    ch == 'O' || ch == 'U')
                {
                    vowels++;
                }
                else
                {
                    consonants++;
                }
            }
        }

        Console.WriteLine("Number of vowels: " + vowels);
        Console.WriteLine("Number of consonants: " + consonants);
    }
}
