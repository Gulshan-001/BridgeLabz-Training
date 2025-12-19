using System;

class KiloToMile2
{
    static void Main()
    {
        double kilometres;
        
        Console.Write("Enter distance in kilometres: ");
        int km = int.Parse(Console.ReadLine());

        kilometres = km;
        double miles = kilometres / 1.609;

        Console.WriteLine("Distance in miles: " + miles);
    }
}
