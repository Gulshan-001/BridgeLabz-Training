using System;
class Divisibility
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number");
        int number1 = Convert.ToInt32(Console.ReadLine());
        if (number1 % 5 == 0)
        {
            Console.WriteLine(number1 + " is divisible by 5");
        }
    }
}