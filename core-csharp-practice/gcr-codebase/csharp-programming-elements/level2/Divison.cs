using System;
class Divison
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number1");
        int number1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter number2");
        int number2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The Quotient is: " + (number1 / number2) + "\nThe Remainder is: " + (number1 % number2) +"of two numbers " + number1 + " and " + number2 );
    }
}