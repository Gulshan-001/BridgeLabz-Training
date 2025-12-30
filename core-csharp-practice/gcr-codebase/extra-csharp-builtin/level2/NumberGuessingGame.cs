using System;

class NumberGuessingGame
{
    static int GenerateGuess(int low, int high)
    {
        Random rand = new Random();
        return rand.Next(low, high + 1);
    }

    static string GetUserFeedback(int guess)
    {
        Console.Write($"Is {guess} too high, too low, or correct? ");
        return Console.ReadLine().ToLower();
    }

    static void Main()
    {
        int low = 1;
        int high = 100;
        bool guessedCorrectly = false;

        Console.WriteLine("Think of a number between 1 and 100.");

        while (!guessedCorrectly)
        {
            // Generate a guess
            int guess = GenerateGuess(low, high);

            // Get feedback from the user
            string feedback = GetUserFeedback(guess);

            // Adjust range based on feedback
            if (feedback == "low")
                low = guess + 1;
            else if (feedback == "high")
                high = guess - 1;
            else if (feedback == "correct")
            {
                Console.WriteLine("Yay! The computer guessed your number.");
                guessedCorrectly = true;
            }
            else
            {
                Console.WriteLine("Please enter only: high, low, or correct.");
            }
        }
    }
}
