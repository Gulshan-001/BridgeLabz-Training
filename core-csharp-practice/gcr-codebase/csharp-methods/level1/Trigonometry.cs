using System;

class Trigonometry
{
    // method to calculate sine, cosine, and tangent for a given angle in degrees
    public static double[] CalculateTrigonometricFunctions(double angle)
    {
        double radians = angle * (Math.PI / 180); // convert degrees to radians
        double sine = Math.Sin(radians);
        double cosine = Math.Cos(radians);
        double tangent = Math.Tan(radians);
        return new double[] { sine, cosine, tangent };
    }

    static void Main(string[] args)
    {
        // take angle in degrees from user
        Console.WriteLine("Enter angle in degrees: ");
        double angle = Convert.ToDouble(Console.ReadLine());

        // calculate trigonometric functions by calling the method
        double[] results = CalculateTrigonometricFunctions(angle);

        Console.WriteLine("Sine: " + results[0]);
        Console.WriteLine("Cosine: " + results[1]);
        Console.WriteLine("Tangent: " + results[2]);
    }
}
