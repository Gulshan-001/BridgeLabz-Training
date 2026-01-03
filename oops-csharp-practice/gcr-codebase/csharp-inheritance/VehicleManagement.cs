using System;

// Interface
interface Refuelable
{
    void Refuel();
}

// Superclass
class Vehicle
{
    public int MaxSpeed;
    public string Model;

    public Vehicle(int maxSpeed, string model)
    {
        MaxSpeed = maxSpeed;
        Model = model;
    }
}

// Electric Vehicle
class ElectricVehicle : Vehicle
{
    public ElectricVehicle(int maxSpeed, string model)
        : base(maxSpeed, model)
    {
    }

    public void Charge()
    {
        Console.WriteLine(Model + " is charging.");
    }
}

// Petrol Vehicle
class PetrolVehicle : Vehicle, Refuelable
{
    public PetrolVehicle(int maxSpeed, string model)
        : base(maxSpeed, model)
    {
    }

    public void Refuel()
    {
        Console.WriteLine(Model + " is refueling petrol.");
    }
}

class Program
{
    static void Main()
    {
        ElectricVehicle ev = new ElectricVehicle(160, "Tesla");
        PetrolVehicle pv = new PetrolVehicle(180, "Honda City");

        ev.Charge();
        pv.Refuel();
    }
}
