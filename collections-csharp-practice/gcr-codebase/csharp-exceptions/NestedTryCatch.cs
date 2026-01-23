using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        try
        {
            Console.Write("Enter array index: ");
            int index = int.Parse(Console.ReadLine());

            int value = numbers[index]; // May throw IndexOutOfRangeException

            try
            {
                Console.Write("Enter divisor: ");
                int divisor = int.Parse(Console.ReadLine());

                int result = value / divisor; // May throw DivideByZeroException
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid array index!");
        }
    }
}
