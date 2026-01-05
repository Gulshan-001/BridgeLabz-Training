using System;

class Customer
{
    public string Name;

    public Customer(string name)
    {
        Name = name;
    }

    public void RentVehicle(Vehicle v, IRentable r, int days)
    {
        Console.WriteLine("Customer: " + Name);
        v.DisplayInfo();
        Console.WriteLine("Total Rent: " + r.CalculateRent(days));
    }
}
