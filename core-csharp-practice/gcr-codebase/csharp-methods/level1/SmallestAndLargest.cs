using System;

class SmallestAndLargest
{
    // method to find smallest and largest among 3 numbers
    public static int[] FindSmallestAndLargest(int number1, int number2, int number3)
    {
        int smallest = number1;
        int largest = number1;

        // check for smallest
        if (number2 < smallest) smallest = number2;
        if (number3 < smallest) smallest = number3;

        // check for largest
        if (number2 > largest) largest = number2;
        if (number3 > largest) largest = number3;

        return new int[] { smallest, largest };
    }

    static void Main(string[] args)
    {
        // take 3 numbers from user
        Console.Write("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        // call method to find smallest and largest
        int[] result = FindSmallestAndLargest(num1, num2, num3);

        Console.WriteLine("Smallest: " + result[0]);
        Console.WriteLine("Largest: " + result[1]);
    }
}
