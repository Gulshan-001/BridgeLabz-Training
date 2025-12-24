using System;

class CalculateWindChill
{
    // method to calculate wind chill temperature
    public static double CalculateWindChill(double temperature, double windSpeed)
    {
        return 35.74 + 0.6215 * temperature + (0.4275 * temperature - 35.75) * Math.Pow(windSpeed, 0.16);
    }

    static void Main(string[] args)
    {
        // take temperature and wind speed from user
        Console.Write("Enter temperature (°F): ");
        double temp = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter wind speed (mph): ");
        double windSpeed = Convert.ToDouble(Console.ReadLine());

        // calculate wind chill by calling the method
        double windChill = CalculateWindChill(temp, windSpeed);

        Console.WriteLine("The Wind Chill Temperature is: " + windChill + "°F");
    }
}
