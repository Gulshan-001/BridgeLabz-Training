using System;
class EarthVol
{
    static void Main()
    {
        int rad=6378;
        int vol=(4/3)*3.14*rad*rad*rad;
        Console.WriteLine("The volume of the Earth in cubic kilometres is " + vol + ".");
    }
}