using System;
class NaturalCheck
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number");
        int number1 = Convert.ToInt32(Console.ReadLine());
        if (number1 >= 0)
        {
            Console.WriteLine("The sum of"+ number1 +"natural numbers is: " + (number1 * (number1 + 1)) / 2);
        }
        else
        {
            Console.WriteLine(number1 + " is not a natural number");
        }
    }
}