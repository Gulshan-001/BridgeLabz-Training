using System;

class EuclidianDistance
{
    // Find Euclidean distance
    public static double GetDistance(double x1, double y1, double x2, double y2)
    {
        double dx = x2 - x1;
        double dy = y2 - y1;
        return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
    }

    // Find slope and y-intercept
    public static double[] GetLineEquation(double x1, double y1, double x2, double y2)
    {
        double m = (y2 - y1) / (x2 - x1);
        double b = y1 - m * x1;
        return new double[] { m, b };
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter x1: ");
        double x1 = double.Parse(Console.ReadLine());

        Console.Write("Enter y1: ");
        double y1 = double.Parse(Console.ReadLine());

        Console.Write("Enter x2: ");
        double x2 = double.Parse(Console.ReadLine());

        Console.Write("Enter y2: ");
        double y2 = double.Parse(Console.ReadLine());

        double distance = GeometryUtility.GetDistance(x1, y1, x2, y2);
        Console.WriteLine("Euclidean Distance: " + distance);

        double[] line = GeometryUtility.GetLineEquation(x1, y1, x2, y2);
        Console.WriteLine("Equation of line: y = " + line[0] + "x + " + line[1]);
    }
}
