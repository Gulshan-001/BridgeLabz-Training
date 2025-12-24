using System;

class SpringCheck
{
    // method to check if given month and day is in Spring season
    static bool IsSpring(int month, int day)
    {
        // Spring: March 20 to June 20
        if ((month == 3 && day >= 20) || (month == 4) || (month == 5) || (month == 6 && day <= 20))
            return true;
        else
            return false;
    }

    static void Main(string[] args)
    {
        // take month and day as input from user
        Console.Write("Enter month (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter day (1-31): ");
        int day = Convert.ToInt32(Console.ReadLine());

        // call method to check for Spring season
        bool spring = IsSpring(month, day);

        if (spring)
            Console.WriteLine("It's a Spring Season.");
        else
            Console.WriteLine("Not a Spring Season.");
    }
}
