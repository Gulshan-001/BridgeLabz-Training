using System;
class SignCheck
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number");
        int number1 = Convert.ToInt32(Console.ReadLine());
        if (number1 > 0)
        {
            Console.WriteLine("positive");
        }
        else if (number1 < 0)
        {
            Console.WriteLine("negative");
        }
        else
        {
            Console.WriteLine("zero");
        }
    }
}