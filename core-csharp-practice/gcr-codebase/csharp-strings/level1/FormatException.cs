using System;

class FormatException
{
    // This method generates FormatException
    static void showError()
    {
        string value = "abc";

        // Trying to convert non-numeric string to int
        int number = int.Parse(value);

        Console.WriteLine(number);
    }

    // This method handles FormatException
    static void handleError()
    {
        try
        {
            string value = "abc";

            int number = int.Parse(value);
            Console.WriteLine(number);
        }
        catch (FormatException)
        {
            Console.WriteLine("Input string is not in a correct numeric format.");
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
