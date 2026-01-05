using System;

class Car : Vehicle, IRentable
{
    public Car(string model, double rate) : base(model, rate) { }

    public double CalculateRent(int days)
    {
        return days * RatePerDay;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Vehicle Type: Car");
        base.DisplayInfo();
    }
}
