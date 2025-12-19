using System;
class TempConversion
{
    static void Main()
    {
        Console.WriteLine("Enter temperature in Celsius:");

        double celsius = Convert.ToDouble(Console.ReadLine());
        double fahrenheit = (celsius * 9 / 5) + 32;
        Console.WriteLine("The " + celsius + " is " + fahrenheit + " Fahrenheit.");
    }
}