using System;

class Program
{
    static void Main()
    {
        try
        {
            Method2();
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Handled exception in Main");
        }
    }

    static void Method1()
    {
        int result = 10 / 0; // ArithmeticException
    }

    static void Method2()
    {
        Method1(); // No handling here, exception propagates
    }
}
