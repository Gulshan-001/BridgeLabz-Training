using System;

class Vehicle
{
    string ownerName;
    string vehicleType;

    static double registrationFee = 5000;

    public Vehicle(string owner, string type)
    {
        ownerName = owner;
        vehicleType = type;
    }

    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner Name: " + ownerName);
        Console.WriteLine("Vehicle Type: " + vehicleType);
        Console.WriteLine("Registration Fee: " + registrationFee);
    }

    public static void UpdateRegistrationFee(double newFee)
    {
        // Updating once affects all vehicles
        registrationFee = newFee;
    }
}

class Program
{
    static void Main()
    {
        Vehicle v1 = new Vehicle("Gulshan", "Car");
        Vehicle v2 = new Vehicle("Amit", "Bike");

        Console.WriteLine("Before Fee Update:");
        v1.DisplayVehicleDetails();
        Console.WriteLine();
        v2.DisplayVehicleDetails();

        Console.WriteLine();

        // Change registration fee for all vehicles
        Vehicle.UpdateRegistrationFee(6500);

        Console.WriteLine("After Fee Update:");
        v1.DisplayVehicleDetails();
        Console.WriteLine();
        v2.DisplayVehicleDetails();
    }
}
