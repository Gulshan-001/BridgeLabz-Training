using System;
using System.IO.Compression;
class Height
{
    static void Main()
    {
        int h=Console.ReadLine("Enter height in centimetres: ");
        int hinches=h/2.54;
        int hfeet=hinches/12;
        Console.WriteLine("Your height in feet is " + hfeet + " and in inches is " + hinches + ".");
    }
}