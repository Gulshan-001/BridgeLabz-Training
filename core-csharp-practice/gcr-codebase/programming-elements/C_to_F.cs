using System;

public class C_to_F
{
    public static void Main(string[] args)
    {
        Console.Write("Enter temperature in Celsius: ");
        if (!double.TryParse(Console.ReadLine(), out double celsius))
        {
            Console.WriteLine("Invalid temperature input.");
            return;
        }

        double fahrenheit = (celsius * 9.0 / 5.0) + 32.0;
        Console.WriteLine(celsius + "°C is equal to " + fahrenheit + "°F");
    }
}
