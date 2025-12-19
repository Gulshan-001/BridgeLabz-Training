using System;
class TrianglePark
{
    static void Main()
    {
        Console.WriteLine("Enter side one");
        double sideOne = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter side two");
        double sideTwo = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter side three");
        double sideThree = Convert.ToDouble(Console.ReadLine());
        double perimeter = sideOne + sideTwo + sideThree;
        int ans=perimeter/5;
        Console.WriteLine("The total number of rounds the athlete will run is " + ans + " to complete 5 km");
        
    }
}