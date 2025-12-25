using System;

class UnitConvertor
{
    // convert kilometers to miles
    public static double ConvertKmToMiles(double km)
    {
        double km2miles = 0.621371;
        return km * km2miles;
    }

    // convert miles to kilometers
    public static double ConvertMilesToKm(double miles)
    {
        double miles2km = 1.60934;
        return miles * miles2km;
    }

    // convert meters to feet
    public static double ConvertMetersToFeet(double meters)
    {
        double meters2feet = 3.28084;
        return meters * meters2feet;
    }

    // convert feet to meters
    public static double ConvertFeetToMeters(double feet)
    {
        double feet2meters = 0.3048;
        return feet * feet2meters;
    }

    static void Main(string[] args)
    {
        // take value from user
        Console.Write("Enter a value: ");
        double value = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("KM to Miles: " + ConvertKmToMiles(value));
        Console.WriteLine("Miles to KM: " + ConvertMilesToKm(value));
        Console.WriteLine("Meters to Feet: " + ConvertMetersToFeet(value));
        Console.WriteLine("Feet to Meters: " + ConvertFeetToMeters(value));
    }
}
