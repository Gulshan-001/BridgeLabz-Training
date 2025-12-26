using System;

class NullException
{
    // Method written FIRST
    static void DemonstrateNullReferenceException()
    {
        try
        {
            string message = null;   // null reference

            // Accessing method/property on null object
            int length = message.Length;

            Console.WriteLine("Length: " + length);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("Exception caught: NullReferenceException");
            Console.WriteLine("Message: " + e.Message);
        }
    }

    // Main method written AFTER
    static void Main()
    {
        DemonstrateNullReferenceException();
    }
}
