using System;
class AreaOfTriangle
{
    static void Main()
    {
        int baseLength=Console.ReadLine("Enter the base length of the triangle: ");
        int height=Console.ReadLine("Enter the height of the triangle: ") ;
        double area=0.5*baseLength*height;
        Console.WriteLine("The area of the triangle is " + area + " square units.");
    }
}