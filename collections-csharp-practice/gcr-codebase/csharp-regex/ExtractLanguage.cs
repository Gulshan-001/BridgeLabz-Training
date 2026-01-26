using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet.";

        string pattern = @"\b(JavaScript|Java|Python|Go)\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
