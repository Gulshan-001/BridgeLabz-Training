using System;
using System.Text;

public class FlipKeyService : IFlipKeyService
{
    public string CleanseAndInvert(string input)
    {
        if (!InputValidator.IsValid(input))
            return string.Empty;

        input = input.ToLower();
        StringBuilder filtered = new StringBuilder();

        // Remove characters with even ASCII values
        foreach (char c in input)
        {
            if ((int)c % 2 != 0)
            {
                filtered.Append(c);
            }
        }

        // Reverse string
        char[] arr = filtered.ToString().ToCharArray();
        Array.Reverse(arr);

        // Convert even positioned characters to uppercase
        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                arr[i] = char.ToUpper(arr[i]);
            }
        }

        return new string(arr);
    }
}
