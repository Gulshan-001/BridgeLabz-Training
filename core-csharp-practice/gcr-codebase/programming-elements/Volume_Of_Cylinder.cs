using System;

public class Volume_Of_Cylinder
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the radius of the cylinder: ");
        if (!double.TryParse(Console.ReadLine(), out double radius))
        {
            Console.WriteLine("Invalid radius input.");
            return;
        }

        Console.Write("Enter the height of the cylinder: ");
        if (!double.TryParse(Console.ReadLine(), out double height))
        {
            Console.WriteLine("Invalid height input.");
            return;
        }

        double volume = Math.PI * radius * radius * height;
        Console.WriteLine("The volume of the cylinder is: " + volume);
    }
}
