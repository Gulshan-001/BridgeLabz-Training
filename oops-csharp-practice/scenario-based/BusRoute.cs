using System;

class BusRoute
{
    public int totalDistance = 0;

    // Adds distance for each stop
    public void AddDistance(int distance)
    {
        totalDistance += distance;
    }
}

class Passenger
{
    // Ask passenger if they want to get off
    public bool WantsToGetOff()
    {
        Console.Write("Do you want to get off at this stop? (yes/no): ");
        string choice = Console.ReadLine();
        return choice.ToLower() == "yes";
    }
}

class Program
{
    static void Main()
    {
        BusRoute bus = new BusRoute();
        Passenger passenger = new Passenger();

        // Continue until passenger gets off
        while (true)
        {
            Console.Write("Enter distance to next stop: ");
            int distance = Convert.ToInt32(Console.ReadLine());

            bus.AddDistance(distance);

            if (passenger.WantsToGetOff())
            {
                break;
            }
        }

        Console.WriteLine("Total distance travelled: " + bus.totalDistance);
    }
}
