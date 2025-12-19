using System;

class CostCal
{
    static void Main()
    {
        Console.Write("Enter the unit price: ");
        int unitPrice = int.Parse(Console.ReadLine());

        Console.Write("Enter the quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        int cost = unitPrice * quantity;

        Console.WriteLine(
            "The total cost is INR " + cost +
            " if the quantity is " + quantity +
            " and unit price is INR " + unitPrice + "."
        );
    }
}
