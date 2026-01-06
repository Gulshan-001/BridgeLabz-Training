using System;
using System.Collections.Generic;

// Insurance interface
interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}

// Abstract Vehicle class
abstract class Vehicle
{
    // Encapsulation
    private string insurancePolicyNumber; // sensitive info

    protected string vehicleNumber;
    protected string type;
    protected double rentalRate;

    // setter for insurance (controlled access)
    public void SetInsurancePolicy(string policyNo)
    {
        insurancePolicyNumber = policyNo;
    }

    // abstract method
    public abstract double CalculateRentalCost(int days);

    // common display method
    public void DisplayCost(int days)
    {
        double rent = CalculateRentalCost(days);
        double insurance = 0;

        if (this is IInsurable)
        {
            insurance = ((IInsurable)this).CalculateInsurance();
        }

        Console.WriteLine("Vehicle Type: " + type);
        Console.WriteLine("Rental Cost: " + rent);
        Console.WriteLine("Insurance Cost: " + insurance);
        Console.WriteLine("------------------------");
    }
}

// Car class
class Car : Vehicle, IInsurable
{
    public Car(string number)
    {
        vehicleNumber = number;
        type = "Car";
        rentalRate = 2000;
    }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days;
    }

    public double CalculateInsurance()
    {
        return 500; // flat insurance
    }

    public string GetInsuranceDetails()
    {
        return "Car Insurance Applied";
    }
}

// Bike class
class Bike : Vehicle, IInsurable
{
    public Bike(string number)
    {
        vehicleNumber = number;
        type = "Bike";
        rentalRate = 500;
    }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days;
    }

    public double CalculateInsurance()
    {
        return 150;
    }

    public string GetInsuranceDetails()
    {
        return "Bike Insurance Applied";
    }
}

// Truck class
class Truck : Vehicle, IInsurable
{
    public Truck(string number)
    {
        vehicleNumber = number;
        type = "Truck";
        rentalRate = 4000;
    }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days;
    }

    public double CalculateInsurance()
    {
        return 1000;
    }

    public string GetInsuranceDetails()
    {
        return "Truck Insurance Applied";
    }
}

class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        vehicles.Add(new Car("CAR101"));
        vehicles.Add(new Bike("BIKE202"));
        vehicles.Add(new Truck("TRK303"));

        int days = 3;

        // Polymorphism here
        foreach (Vehicle v in vehicles)
        {
            v.DisplayCost(days);
        }
    }
}
