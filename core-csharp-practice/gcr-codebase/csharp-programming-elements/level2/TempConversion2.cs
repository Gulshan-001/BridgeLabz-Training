using System;

class TempConversion
{
    static void Main()
    {
        Console.WriteLine("Enter temperature in Fahrenheit:");

        double fahrenheit = Convert.ToDouble(Console.ReadLine());
        double celsius = (fahrenheit - 32) * 5 / 9;

        Console.WriteLine("The " + fahrenheit + " is " + celsius + " Celsius.");
    }
}
