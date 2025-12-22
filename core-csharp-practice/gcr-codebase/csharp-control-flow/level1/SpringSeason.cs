using System;
class SpringSeason
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter month number:");
        int month = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter day number:");
        int day = Convert.ToInt32(Console.ReadLine());
        if (month >= 3 && day >= 20 && month <= 5)
        {
            Console.WriteLine("It is Spring season.");
        }
        else
        {
            Console.WriteLine("It is not Spring season.");
        }
    }
}