using System;

class Electronics : WarehouseItem
{
    public Electronics(string name) : base(name) { }

    public override void Display()
    {
        Console.WriteLine("Electronics Item: " + Name);
    }
}
