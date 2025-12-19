using System;
class SquareSide
{
    static void Main()
    {
        int perimeter=Console.ReadLine("Enter the perimeter of the square: ");
        int side=perimeter/4;   
        Console.WriteLine("The length of the side is" + side + " whose perimeter is " + perimeter);
        
    }
}