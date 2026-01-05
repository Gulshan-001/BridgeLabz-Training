using System;

class Program
{
    static void Main()
    {
        Customer c = new Customer("Aman");

        Vehicle v = new Car("Honda City", 2000);
        IRentable r = (IRentable)v;
        
        c.RentVehicle(v, r, 3);
    }
}
