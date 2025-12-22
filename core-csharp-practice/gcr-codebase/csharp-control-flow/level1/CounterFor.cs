using System;
public class CounterFor
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());
        for (int i = number; i > 0; i--)
        {
            Console.WriteLine("Current number: " + i);
        }
    }
}