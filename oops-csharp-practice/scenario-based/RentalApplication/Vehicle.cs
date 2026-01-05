using System;

// Base class
class Vehicle
{
    protected string Model;        // accessible in child classes
    protected double RatePerDay;

    public Vehicle(string model, double rate)
    {
        Model = model;
        RatePerDay = rate;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Rate per day: " + RatePerDay);
    }
}
