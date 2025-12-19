using System;
class CostCal
{
    static void Main()
    {
        int unitPrice=Console.ReadLine("Enter the unit price: ");
        int quantity=Console.ReadLine("Enter the quantity: ");
        int cost=unitPrice*quantity;
        Console.WriteLine("The total cost is INR " + cost +"if the quantity is " + quantity + " and unit price is INR " + unitPrice + ".");
    }
}