using System;

class ArgumentOutOfRangeException
{
    // This method generates ArgumentOutOfRangeException
    static void showError()
    {
        string text = "Programming";

        // Start index is greater than string length
        string part = text.Substring(15, 3);

        Console.WriteLine(part);
    }

    // This method handles ArgumentOutOfRangeException
    static void handleError()
    {
        try
        {
            string text = "Programming";

            string part = text.Substring(15, 3);
            Console.WriteLine(part);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Substring indices are outside the valid range.");
        }
    }

    static void Main()
    {
        // Uncomment to see the exception without handling
        // showError();

        // Safe execution using try-catch
        handleError();
    }
}
