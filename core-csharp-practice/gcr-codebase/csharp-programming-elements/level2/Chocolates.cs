using System;

class Chocolates
{
    static void Main()
    {
        Console.WriteLine("Enter number of chocolates:");
        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of children:");
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());

        int chocolatesPerChild = numberOfChocolates / numberOfChildren;
        int remainingChocolates = numberOfChocolates % numberOfChildren;

        Console.WriteLine(
            "The number of chocolates each child gets is " +
            chocolatesPerChild +
            " and the number of remaining chocolates is " +
            remainingChocolates
        );
    }
}
