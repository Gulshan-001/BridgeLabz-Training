using System;

// Parent class
class Vehicle
{
    public int MaxSpeed;
    public string FuelType;

    public Vehicle(int maxSpeed, string fuelType)
    {
        MaxSpeed = maxSpeed;
        FuelType = fuelType;
    }

    // This will be overridden
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Max Speed: " + MaxSpeed);
        Console.WriteLine("Fuel Type: " + FuelType);
    }
}

// Car class
class Car : Vehicle
{
    public int SeatCapacity;

    public Car(int maxSpeed, string fuelType, int seats)
        : base(maxSpeed, fuelType)
    {
        SeatCapacity = seats;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Car Details");
        base.DisplayInfo();
        Console.WriteLine("Seats: " + SeatCapacity);
    }
}

// Truck class
class Truck : Vehicle
{
    public int PayloadCapacity;

    public Truck(int maxSpeed, string fuelType, int payload)
        : base(maxSpeed, fuelType)
    {
        PayloadCapacity = payload;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Truck Details");
        base.DisplayInfo();
        Console.WriteLine("Payload Capacity: " + PayloadCapacity + " kg");
    }
}

// Motorcycle class
class Motorcycle : Vehicle
{
    public bool HasSidecar;

    public Motorcycle(int maxSpeed, string fuelType, bool sidecar)
        : base(maxSpeed, fuelType)
    {
        HasSidecar = sidecar;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Motorcycle Details");
        base.DisplayInfo();
        Console.WriteLine("Has Sidecar: " + HasSidecar);
    }
}

class Program
{
    static void Main()
    {
        // Polymorphism happening here
        Vehicle[] vehicles = new Vehicle[3];

        vehicles[0] = new Car(180, "Petrol", 5);
        vehicles[1] = new Truck(120, "Diesel", 10000);
        vehicles[2] = new Motorcycle(150, "Petrol", false);

        for (int i = 0; i < vehicles.Length; i++)
        {
            vehicles[i].DisplayInfo();
            Console.WriteLine();
        }
    }
}