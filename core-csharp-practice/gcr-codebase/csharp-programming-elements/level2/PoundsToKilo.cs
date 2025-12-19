using System;
class PoundsToKilo
{
    static void Main()
    {
        Console.WriteLine("Enter weight in Pounds:");

        double pounds = Convert.ToDouble(Console.ReadLine());
        double kilos = pounds * 0.45359237;

        Console.WriteLine("The weight of the the person in pounds is " + pounds + " and in kilos is " + kilos);
    }
}