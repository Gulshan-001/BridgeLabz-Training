using System;

class Circle
{
    double radius;

    // Default constructor
    public Circle() : this(1.0)
    {
        // Default radius is set by calling the parameterized constructor
    }

    // Parameterized constructor
    public Circle(double r)
    {
        radius = r;
    }

    public void DisplayRadius()
    {
        Console.WriteLine("Radius: " + radius);
    }
}

class Program
{
    static void Main()
    {
        // Using default constructor
        Circle c1 = new Circle();
        c1.DisplayRadius();

        Console.WriteLine();

        // Using parameterized constructor
        Console.Write("Enter radius: ");
        double r = Convert.ToDouble(Console.ReadLine());

        Circle c2 = new Circle(r);
        c2.DisplayRadius();
    }
}
