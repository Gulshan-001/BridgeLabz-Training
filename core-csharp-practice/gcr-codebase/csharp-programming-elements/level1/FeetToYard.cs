using System;
class FeetToYard
{
    static void Main()
    {
        double feet;
        int ft=Console.ReadLine("Enter distance in feet: ");
        feet=ft;
        double yards=feet/3;
        double inches=feet*12;
        Console.WriteLine("The distance in yards is " + yards + " and in inches is " + inches + ".");

}
}