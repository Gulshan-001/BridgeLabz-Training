using System;

class Collinearity
{
    // b. Check collinearity using slope formula
    public static bool IsCollinearBySlope(double x1, double y1,
                                          double x2, double y2,
                                          double x3, double y3)
    {
        double slopeAB = (y2 - y1) / (x2 - x1);
        double slopeBC = (y3 - y2) / (x3 - x2);
        double slopeAC = (y3 - y1) / (x3 - x1);

        return slopeAB == slopeBC && slopeBC == slopeAC;
    }

    // c. Check collinearity using area of triangle formula
    public static bool IsCollinearByArea(double x1, double y1,
                                         double x2, double y2,
                                         double x3, double y3)
    {
        double area = 0.5 * (x1 * (y2 - y3)
                           + x2 * (y3 - y1)
                           + x3 * (y1 - y2));

        return area == 0;
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

        Console.Write("Enter x3: ");
        double x3 = double.Parse(Console.ReadLine());
        Console.Write("Enter y3: ");
        double y3 = double.Parse(Console.ReadLine());

        bool slopeResult = CollinearChecker.IsCollinearBySlope(x1, y1, x2, y2, x3, y3);
        bool areaResult = CollinearChecker.IsCollinearByArea(x1, y1, x2, y2, x3, y3);

        Console.WriteLine("Collinear using slope method? " + (slopeResult ? "Yes" : "No"));
        Console.WriteLine("Collinear using area method? " + (areaResult ? "Yes" : "No"));
    }
}
