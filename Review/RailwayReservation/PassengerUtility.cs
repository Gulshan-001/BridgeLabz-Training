using System;
namespace RailwayReservation
{
public class PassengerUtility : IPassenger
{
    private Passenger[] passengers;
    private int count;

    public PassengerUtility()
    {
        passengers = new Passenger[10];
        count = 0;
    }

    public void addPassengers()
    {
        Console.Write("Enter PNR: ");
        int pnr = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Passenger Type (1-Normal, 2-Senior): ");
        int type = int.Parse(Console.ReadLine());

        Passenger passenger;
        if (type == 2)
            passenger = new SeniorPassenger(pnr, age, name);
        else
            passenger = new NormalPassenger(pnr, age, name);

        passengers[count++] = passenger;
        Console.WriteLine("Passenger added successfully!\n");
    }

    // Bubble Sort by PNR
    public void sortPassengers()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (passengers[j].Pnr > passengers[j + 1].Pnr)
                {
                    Passenger temp = passengers[j];
                    passengers[j] = passengers[j + 1];
                    passengers[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Passengers sorted by PNR.\n");
    }

    // Binary Search
    public Passenger SearchPassenger(int pnr)
{
    int left = 0, right = count - 1;

    while (left <= right)
    {
        int mid = (left + right) / 2;

        if (passengers[mid].Pnr == pnr)
        {
            return passengers[mid];
        }
        else if (passengers[mid].Pnr < pnr)
            left = mid + 1;
        else
            right = mid - 1;
    }

    return null;
}


    public void displayPassengers()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"PNR: {passengers[i].Pnr}, Name: {passengers[i].Name}, Age: {passengers[i].Age}");
        }
        Console.WriteLine();
    }
}
}