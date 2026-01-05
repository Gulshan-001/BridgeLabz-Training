using System;

class Truck : Vehicle, IRentable
{
    public Truck(string model, double rate) : base(model, rate) { }

    public double CalculateRent(int days)
    {
        return days * RatePerDay;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Vehicle Type: Truck");
        base.DisplayInfo();
    }
}
