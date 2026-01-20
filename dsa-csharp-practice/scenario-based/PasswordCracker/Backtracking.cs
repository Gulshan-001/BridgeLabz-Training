using System;

class Backtracking
{
    private bool found = false;
    private int attemptCount = 0;   // counts attempts

    public void Crack(char[] characters, int length, string password)
    {
        char[] current = new char[length];
        Generate(characters, current, 0, password);

        if (!found)
        {
            Console.WriteLine("\nPassword not found after " + attemptCount + " attempts");
        }
    }
    // recursive backtracking function
    private void Generate(char[] chars, char[] current, int index, string password)
    {
        // stop recursion once password is found
        if (found)
            return;

        // base case: full string formed
        if (index == current.Length)
        {
            attemptCount++;
            string attempt = new string(current);

            Console.WriteLine("Attempt " + attemptCount + ": " + attempt);

            if (attempt == password)
            {
                Console.WriteLine("\nPassword cracked!");
                Console.WriteLine("Password: " + attempt);
                Console.WriteLine("Total attempts: " + attemptCount);
                found = true;
            }
            return;
        }
        // try each character at current position
        for (int i = 0; i < chars.Length; i++)
        {
            current[index] = chars[i];     // choose
            Generate(chars, current, index + 1, password); // explore
            // backtracking happens automatically
        }
    }
}