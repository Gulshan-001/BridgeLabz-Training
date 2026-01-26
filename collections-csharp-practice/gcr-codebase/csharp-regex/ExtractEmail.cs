using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = "Contact us at support@example.com and info@company.org";

        string pattern = @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}";

        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
