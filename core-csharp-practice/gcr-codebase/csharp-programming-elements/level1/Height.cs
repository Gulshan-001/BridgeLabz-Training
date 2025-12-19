using System;

class Height
{
    static void Main()
    {
        Console.Write("Enter height in centimetres: ");
        int h = int.Parse(Console.ReadLine());

        int hinches = (int)(h / 2.54);
        int hfeet = hinches / 12;

        Console.WriteLine("Your height in feet is " + hfeet + 
                          " and in inches is " + hinches + ".");
    }
}
