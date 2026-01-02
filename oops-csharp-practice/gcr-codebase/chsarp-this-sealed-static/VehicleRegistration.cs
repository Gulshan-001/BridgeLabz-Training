using System;

class VehicleRegistration
{
    // Static variable shared by all vehicles
    public static double RegistrationFee = 5000;

    public string OwnerName;
    public string VehicleType;
    public readonly string RegistrationNumber;

    public VehicleRegistration(string ownerName, string vehicleType, string registrationNumber)
    {
        // Using this to assign constructor values
        this.OwnerName = ownerName;
        this.VehicleType = vehicleType;
        this.RegistrationNumber = registrationNumber;
    }

    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner Name: " + OwnerName);
        Console.WriteLine("Vehicle Type: " + VehicleType);
        Console.WriteLine("Registration Number: " + RegistrationNumber);
        Console.WriteLine("Registration Fee: " + RegistrationFee);
    }

    public static void UpdateRegistrationFee(double newFee)
    {
        // Updating fee for all vehicles
        RegistrationFee = newFee;
    }
}

class Program
{
    static void Main()
    {
        VehicleRegistration v1 =
            new VehicleRegistration("Gulshan", "Car", "MH12AB1234");

        VehicleRegistration v2 =
            new VehicleRegistration("Amit", "Bike", "MH14XY5678");

        Console.WriteLine("Before Fee Update:");

        // Using is operator before displaying details
        if (v1 is VehicleRegistration)
        {
            v1.DisplayVehicleDetails();
        }

        Console.WriteLine();

        if (v2 is VehicleRegistration)
        {
            v2.DisplayVehicleDetails();
        }

        Console.WriteLine();

        // Update registration fee for all vehicles
        VehicleRegistration.UpdateRegistrationFee(6500);

        Console.WriteLine("After Fee Update:");
        v1.DisplayVehicleDetails();
        Console.WriteLine();
        v2.DisplayVehicleDetails();
    }
}
