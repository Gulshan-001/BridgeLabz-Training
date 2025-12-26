using System;

class CompareStrings
{
    static void Main()
    {
        // Input two strings from the user
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        int i = 0;
        int minLength = (str1.Length < str2.Length) ? str1.Length : str2.Length;

        // Compare characters one by one
        while (i < minLength)
        {
            if (str1[i] != str2[i])
                break;
            i++;
        }

        // Determine lexicographical order
        if (i == minLength)
        {
            if (str1.Length == str2.Length)
                Console.WriteLine("Both strings are equal.");
            else if (str1.Length < str2.Length)
                Console.WriteLine($"\"{str1}\" comes before \"{str2}\" in lexicographical order.");
            else
                Console.WriteLine($"\"{str2}\" comes before \"{str1}\" in lexicographical order.");
        }
        else
        {
            if (str1[i] < str2[i])
                Console.WriteLine($"\"{str1}\" comes before \"{str2}\" in lexicographical order.");
            else
                Console.WriteLine($"\"{str2}\" comes before \"{str1}\" in lexicographical order.");
        }
    }
}
