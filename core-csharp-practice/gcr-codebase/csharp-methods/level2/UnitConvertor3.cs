using System;

class UnitConvertor3
{
    // convert Fahrenheit to Celsius
    public static double ConvertFahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    // convert Celsius to Fahrenheit
    public static double ConvertCelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    // convert pounds to kilograms
    public static double ConvertPoundsToKilograms(double pounds)
    {
        double pounds2kilograms = 0.453592;
        return pounds * pounds2kilograms;
    }

    // convert kilograms to pounds
    public static double ConvertKilogramsToPounds(double kilograms)
    {
        double kilograms2pounds = 2.20462;
        return kilograms * kilograms2pounds;
    }

    // convert gallons to liters
    public static double ConvertGallonsToLiters(double gallons)
    {
        double gallons2liters = 3.78541;
        return gallons * gallons2liters;
    }

    // convert liters to gallons
    public static double ConvertLitersToGallons(double liters)
    {
        double liters2gallons = 0.264172;
        return liters * liters2gallons;
    }

    static void Main(string[] args)
    {
        // take value from user
        Console.Write("Enter a value: ");
        double value = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Fahrenheit to Celsius: " + ConvertFahrenheitToCelsius(value));
        Console.WriteLine("Celsius to Fahrenheit: " + ConvertCelsiusToFahrenheit(value));
        Console.WriteLine("Pounds to Kilograms: " + ConvertPoundsToKilograms(value));
        Console.WriteLine("Kilograms to Pounds: " + ConvertKilogramsToPounds(value));
        Console.WriteLine("Gallons to Liters: " + ConvertGallonsToLiters(value));
        Console.WriteLine("Liters to Gallons: " + ConvertLitersToGallons(value));
    }
}
