using System;

class AreaOfCircle
{
    double radius;

    // Constructor to set the radius
    public AreaOfCircle(double r)
    {
        radius = r;
    }

    public void CalculateArea()
    {
        // Area formula: π * r * r
        double area = Math.PI * radius * radius;
        Console.WriteLine("Area of the circle: " + area);
    }

    public void CalculateCircumference()
    {
        // Circumference formula: 2 * π * r
        double circumference = 2 * Math.PI * radius;
        Console.WriteLine("Circumference of the circle: " + circumference);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter radius: ");
        double radius = Convert.ToDouble(Console.ReadLine());

        // Creating object and passing radius
        AreaOfCircle circle = new AreaOfCircle(radius);

        circle.CalculateArea();
        circle.CalculateCircumference();
    }
}
