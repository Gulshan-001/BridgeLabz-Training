using System;

class Groceries : WarehouseItem
{
    public Groceries(string name) : base(name) { }

    public override void Display()
    {
        Console.WriteLine("Grocery Item: " + Name);
    }
}
