using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "This   is    an   example   with   multiple   spaces.";

        string result = Regex.Replace(input, @"\s+", " ");

        Console.WriteLine(result);
    }
}
