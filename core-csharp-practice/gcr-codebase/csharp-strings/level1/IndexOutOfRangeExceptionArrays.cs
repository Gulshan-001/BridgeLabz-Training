using System;

class IndexOutOfRangeExceptionArrays
{
    // This method generates IndexOutOfRangeException
    static void showError()
    {
        int[] numbers = { 10, 20, 30, 40 };

        // Array length is 4, valid indices are 0 to 3
        int value = numbers[6];

        Console.WriteLine(value);
    }

    // This method handles IndexOutOfRangeException
    static void handleError()
    {
        try
        {
            int[] numbers = { 10, 20, 30, 40 };

            int value = numbers[6];
            Console.WriteLine(value);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Array index accessed is outside the valid range.");
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
