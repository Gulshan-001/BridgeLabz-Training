using System;
class Counter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());
        while (number > 0)
        {
            Console.WriteLine("Current number: " + number);
            number--;
        }
}
}