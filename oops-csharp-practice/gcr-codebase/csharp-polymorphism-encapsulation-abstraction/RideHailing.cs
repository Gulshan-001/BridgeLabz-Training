using System;

// GPS interface
interface IGPS
{
    void GetCurrentLocation();
    void UpdateLocation(string newLocation);
}

// abstract class
abstract class Vehicle
{
    // encapsulated fields
    private int vehicleId;
    private string driverName;
    protected double ratePerKm;

    protected string location;

    public Vehicle(int id, string driver, double rate)
    {
        vehicleId = id;
        driverName = driver;
        ratePerKm = rate;
        location = "Unknown";
    }

    // abstract method
    public abstract double CalculateFare(double distance);

    // concrete method
    public void GetVehicleDetails()
    {
        Console.WriteLine("Vehicle ID: " + vehicleId);
        Console.WriteLine("Driver Name: " + driverName);
        Console.WriteLine("Rate per KM: ₹" + ratePerKm);
    }
}

// Car class
class Car : Vehicle, IGPS
{
    public Car(int id, string driver) : base(id, driver, 15) { }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }

    public void GetCurrentLocation()
    {
        Console.WriteLine("Car location: " + location);
    }

    public void UpdateLocation(string newLocation)
    {
        location = newLocation;
    }
}

// Bike class
class Bike : Vehicle, IGPS
{
    public Bike(int id, string driver) : base(id, driver, 8) { }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }

    public void GetCurrentLocation()
    {
        Console.WriteLine("Bike location: " + location);
    }

    public void UpdateLocation(string newLocation)
    {
        location = newLocation;
    }
}

// Auto class
class Auto : Vehicle, IGPS
{
    public Auto(int id, string driver) : base(id, driver, 10) { }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }

    public void GetCurrentLocation()
    {
        Console.WriteLine("Auto location: " + location);
    }

    public void UpdateLocation(string newLocation)
    {
        location = newLocation;
    }
}

// main program
class Program
{
    static void Main()
    {
        // polymorphism using Vehicle array
        Vehicle[] rides = new Vehicle[]
        {
            new Car(1, "Ramesh"),
            new Bike(2, "Suresh"),
            new Auto(3, "Mahesh")
        };

        double distance = 5; // km

        foreach (Vehicle v in rides)
        {
            Console.WriteLine("---- Ride Details ----");
            v.GetVehicleDetails();
            Console.WriteLine("Fare for " + distance + " km: ₹" + v.CalculateFare(distance));

            // interface check
            if (v is IGPS gps)
            {
                gps.UpdateLocation("City Center");
                gps.GetCurrentLocation();
            }

            Console.WriteLine();
        }
    }
}
