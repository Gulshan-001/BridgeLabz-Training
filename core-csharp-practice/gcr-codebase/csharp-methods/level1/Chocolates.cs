using System;

class Chocolates
{
    // method to calculate chocolates per child and remaining chocolates
    public static int[] DivideChocolates(int totalChocolates, int children)
    {
        int perChild = totalChocolates / children;
        int remaining = totalChocolates % children;
        return new int[] { perChild, remaining };
    }

    static void Main(string[] args)
    {
        // take total chocolates and number of children from user
        Console.Write("Enter total number of chocolates: ");
        int totalChocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of children: ");
        int children = Convert.ToInt32(Console.ReadLine());

        // call method to get distribution
        int[] result = DivideChocolates(totalChocolates, children);

        Console.WriteLine("Each child gets: " + result[0] + " chocolates");
        Console.WriteLine("Remaining chocolates: " + result[1]);
    }
}
