using System;

class TravelComputation
{
    public static void Main(string[] args)
    {
        // Create a variable 'name' to indicate the person traveling
        Console.WriteLine("Enter traveller name:");
        string name = Console.ReadLine();

        // Create variables 'fromCity', 'viaCity', and 'toCity' for the cities
        Console.WriteLine("Enter starting city:");
        string fromCity = Console.ReadLine();

        Console.WriteLine("Enter via city:");
        string viaCity = Console.ReadLine();

        Console.WriteLine("Enter destination city:");
        string toCity = Console.ReadLine();

        // Create variables for distances (in miles)
        Console.WriteLine("Enter distance from start city to via city (in miles):");
        double distanceFromToVia = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter distance from via city to destination (in miles):");
        double distanceViaToFinalCity = Convert.ToDouble(Console.ReadLine());

        // Create variables for time (in minutes)
        Console.WriteLine("Enter time taken from start city to via city (in minutes):");
        int timeFromToVia = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter time taken from via city to destination (in minutes):");
        int timeViaToFinalCity = Convert.ToInt32(Console.ReadLine());

        // Compute the total distance and total time
        double totalDistance = distanceFromToVia + distanceViaToFinalCity;
        int totalTime = timeFromToVia + timeViaToFinalCity;

        // Print the travel details
        Console.WriteLine(
            $"The Total Distance travelled by {name} from {fromCity} to {toCity} via {viaCity} is {totalDistance} miles and the Total Time taken is {totalTime} minutes"
        );
    }
}
