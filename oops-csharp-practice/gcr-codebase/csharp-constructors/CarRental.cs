using System;

class CarRental
{
    string customerName;
    string carModel;
    int rentalDays;
    double costPerDay;

    // Default constructor
    public CarRental()
    {
        customerName = "Customer";
        carModel = "Basic";
        rentalDays = 1;
        costPerDay = 1000;
    }

    // Parameterized constructor
    public CarRental(string name, string model, int days, double pricePerDay)
    {
        customerName = name;
        carModel = model;
        rentalDays = days;
        costPerDay = pricePerDay;
    }

    public double CalculateTotalCost()
    {
        // Total cost depends on number of days
        return rentalDays * costPerDay;
    }

    public void DisplayRental()
    {
        Console.WriteLine("Customer Name: " + customerName);
        Console.WriteLine("Car Model: " + carModel);
        Console.WriteLine("Rental Days: " + rentalDays);
        Console.WriteLine("Total Cost: " + CalculateTotalCost());
    }
}

class Program
{
    static void Main()
    {
        // Default rental
        CarRental rental1 = new CarRental();
        Console.WriteLine("Default Rental:");
        rental1.DisplayRental();

        Console.WriteLine();

        // Parameterized rental
        CarRental rental2 = new CarRental("Gulshan", "Sedan", 4, 1800);
        Console.WriteLine("Parameterized Rental:");
        rental2.DisplayRental();
    }
}
