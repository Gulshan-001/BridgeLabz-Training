using System;

class LeapCheck
{
    // method to check whether a year is a leap year
    static bool IsLeapYear(int year)
    {
        // leap year works only for Gregorian calendar years
        if (year < 1582)
            return false;

        // leap year conditions
        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            return true;

        return false;
    }

    static void Main(string[] args)
    {
        // take year input from user
        Console.Write("Enter a year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        // check leap year by calling method
        bool isLeap = IsLeapYear(year);

        if (isLeap)
            Console.WriteLine(year + " is a Leap Year.");
        else
            Console.WriteLine(year + " is not a Leap Year.");
    }
}
