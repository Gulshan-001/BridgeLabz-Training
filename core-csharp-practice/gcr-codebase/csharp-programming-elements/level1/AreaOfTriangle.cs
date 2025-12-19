using System;

class AreaOfTriangle
{
    static void Main()
    {
        Console.Write("Enter the base length of the triangle: ");
        int baseLength = int.Parse(Console.ReadLine());

        Console.Write("Enter the height of the triangle: ");
        int height = int.Parse(Console.ReadLine());

        double area = 0.5 * baseLength * height;

        Console.WriteLine("The area of the triangle is " + area + " square units.");
    }
}
