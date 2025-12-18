using System;

public class Palindrome_Number
{
    public static bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }

        int rev = 0;
        int num = x;

        while (num != 0)
        {
            rev = rev * 10 + num % 10; // Add last digit
            num = num / 10;            // Remove last digit
        }

        return (rev == x);
    }

    public static void Main(string[] args)
    {
        int x = 121; // change this number to test

        if (IsPalindrome(x))
        {
            Console.WriteLine(x + " is a Palindrome number");
        }
        else
        {
            Console.WriteLine(x + " is NOT a Palindrome number");
        }
    }
}
