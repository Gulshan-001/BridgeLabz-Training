using System;

class FeetToYard
{
    static void Main()
    {
        double feet;

        Console.Write("Enter distance in feet: ");
        int ft = int.Parse(Console.ReadLine());

        feet = ft;
        double yards = feet / 3;
        double inches = feet * 12;

        Console.WriteLine("The distance in yards is " + yards +
                          " and in inches is " + inches + ".");
    }
}
