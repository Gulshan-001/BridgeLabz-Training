using System;
class SwapTwo
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        int firstNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        int secondNumber = Convert.ToInt32(Console.ReadLine());

        int temp=firstNumber;
        int firstNumber=secondNumber;
        int secondNumber=temp;
        Console.WriteLine("The Swapped numbers are " + firstNumber + "and" + secondNumber);
            }
}