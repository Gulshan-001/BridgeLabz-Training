using System.Text.RegularExpressions;

public class InputValidator
{
    public static bool IsValid(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return false;

        // Only alphabets allowed (no space, digit, special char)
        return Regex.IsMatch(input, "^[A-Za-z]+$");
    }
}
