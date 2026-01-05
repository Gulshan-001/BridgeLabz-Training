using System;

class Bike : Vehicle, IRentable
{
    public Bike(string model, double rate) : base(model, rate) { }

    public double CalculateRent(int days)
    {
        return days * RatePerDay;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Vehicle Type: Bike");
        base.DisplayInfo();
    }
}
