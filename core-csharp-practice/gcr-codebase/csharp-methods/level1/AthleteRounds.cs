using System;

class AthleteRounds
{
    // method to calculate number of rounds needed for 5 km run
    static double CalculateRounds(double side1, double side2, double side3)
    {
        double perimeter = side1 + side2 + side3; // total distance of one lap
        double totalDistance = 5000; // 5 km in meters
        return totalDistance / perimeter; // rounds = total distance / one lap
    }

    static void Main(string[] args)
    {
        // take sides of the triangular park from user
        Console.Write("Enter side 1 of the triangle (in meters): ");
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 2 of the triangle (in meters): ");
        double side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 3 of the triangle (in meters): ");
        double side3 = Convert.ToDouble(Console.ReadLine());

        // calculate required rounds
        double rounds = CalculateRounds(side1, side2, side3);

        Console.WriteLine(
            "To complete a 5 km run, the athlete must run " + rounds + " rounds around the park."
        );
    }
}
