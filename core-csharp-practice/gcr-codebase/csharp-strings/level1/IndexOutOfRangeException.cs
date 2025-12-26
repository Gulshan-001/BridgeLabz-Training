using System;

class IndexOutOfRangeDemo
{
    // This method causes IndexOutOfRangeException
    static void showError()
    {
        string word = "Hello";

        // String length is 5, valid indices are 0 to 4
        char letter = word[6];

        Console.WriteLine(letter);
    }

    // This method handles IndexOutOfRangeException
    static void handleError()
    {
        try
        {
            string word = "Hello";

            char letter = word[6];
            Console.WriteLine(letter);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Index accessed is outside the valid range of the string.");
        }
    }

    static void Main()
    {
        // Uncomment to see the exception without handling
        // showError();

        // Exception handled using try-catch
        handleError();
    }
}
