using System;

class TemperatureConverter
{
    static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    static void Main()
    {
        // Take temperature from the user
        Console.Write("Enter temperature value: ");
        double value = double.Parse(Console.ReadLine());

        Console.Write("Convert to (C/F): ");
        char choice = Console.ReadLine()[0];

        // Perform conversion and display result
        if (choice == 'C' || choice == 'c')
            Console.WriteLine("Temperature in Celsius: " + FahrenheitToCelsius(value));
        else if (choice == 'F' || choice == 'f')
            Console.WriteLine("Temperature in Fahrenheit: " + CelsiusToFahrenheit(value));
        else
            Console.WriteLine("Invalid choice.");
    }
}
