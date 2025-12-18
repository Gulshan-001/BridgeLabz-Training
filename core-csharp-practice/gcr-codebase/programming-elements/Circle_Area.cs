using System;

public class Circle_Area
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the radius of the circle: ");
        if (!double.TryParse(Console.ReadLine(), out double radius))
        {
            Console.WriteLine("Invalid radius input.");
            return;
        }

        double area = Math.PI * radius * radius;
        Console.WriteLine("The area of the circle with radius " + radius + " is: " + area);
    }
}
