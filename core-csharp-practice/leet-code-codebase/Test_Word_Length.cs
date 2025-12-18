using System;

public class Test_Word_Length
{
    public static int LengthOfLastWord(string s)
    {
        // Remove leading and trailing spaces
        s = s.Trim();

        // Split the string by spaces
        string[] words = s.Split(' ');

        // Return length of the last word
        return words[words.Length - 1].Length;
    }

    public static void Main(string[] args)
    {
        string s = "Hello World   ";

        int result = LengthOfLastWord(s);

        Console.WriteLine("Length of last word: " + result);
    }
}
