using System;

class SignCheck
{
    // method to check if number is positive, negative, or zero
    static int CheckNumber(int num)
    {
        if (num > 0)
            return 1;   // positive
        else if (num < 0)
            return -1;  // negative
        else
            return 0;   // zero
    }

    static void Main(string[] args)
    {
        // ask user to enter a number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // call method to check number
        int result = CheckNumber(number);

        // display result
        if (result == 1)
            Console.WriteLine(number + " is positive.");
        else if (result == -1)
            Console.WriteLine(number + " is negative.");
        else
            Console.WriteLine("The number is zero.");
    }
}
