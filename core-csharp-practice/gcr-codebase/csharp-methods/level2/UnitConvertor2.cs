using System;

class UnitConvertor2
{
    // convert yards to feet
    public static double ConvertYardsToFeet(double yards)
    {
        double yards2feet = 3;
        return yards * yards2feet;
    }

    // convert feet to yards
    public static double ConvertFeetToYards(double feet)
    {
        double feet2yards = 0.333333;
        return feet * feet2yards;
    }

    // convert meters to inches
    public static double ConvertMetersToInches(double meters)
    {
        double meters2inches = 39.3701;
        return meters * meters2inches;
    }

    // convert inches to meters
    public static double ConvertInchesToMeters(double inches)
    {
        double inches2meters = 0.0254;
        return inches * inches2meters;
    }

    // convert inches to centimeters
    public static double ConvertInchesToCentimeters(double inches)
    {
        double inches2cm = 2.54;
        return inches * inches2cm;
    }

    static void Main(string[] args)
    {
        // take value from user
        Console.Write("Enter a value: ");
        double value = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Yards to Feet: " + ConvertYardsToFeet(value));
        Console.WriteLine("Feet to Yards: " + ConvertFeetToYards(value));
        Console.WriteLine("Meters to Inches: " + ConvertMetersToInches(value));
        Console.WriteLine("Inches to Meters: " + ConvertInchesToMeters(value));
        Console.WriteLine("Inches to Centimeters: " + ConvertInchesToCentimeters(value));
    }
}
