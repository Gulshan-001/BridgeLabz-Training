using System;

class TrafficManagerUtilityImpl : ITrafficManagerOperations
{
    private CircularRoundabout roundabout;
    private VehicleQueue waitingQueue;

    public TrafficManagerUtilityImpl()
    {
        // you can tweak these numbers
        roundabout = new CircularRoundabout(5);   // max 5 vehicles inside
        waitingQueue = new VehicleQueue(5);       // max 5 vehicles waiting
    }

    // VEHICLE TRIES TO ENTER ROUNDABOUT
    public void EnterRoundabout(Vehicle vehicle)
    {
        // if space available, directly add
        if (roundabout.HasSpace())
        {
            roundabout.AddVehicle(vehicle);
            Console.WriteLine("Vehicle entered roundabout");
        }
        else
        {
            // otherwise go to waiting queue
            waitingQueue.Enqueue(vehicle);
        }
    }

    // VEHICLE EXITS ROUNDABOUT
    public void ExitRoundabout(int vehicleId)
    {
        bool removed = roundabout.RemoveVehicle(vehicleId);

        if (!removed)
        {
            Console.WriteLine("Vehicle not found in roundabout");
            return;
        }

        Console.WriteLine("Vehicle exited roundabout");

        // after exit, allow waiting vehicle to enter
        if (!waitingQueue.IsEmpty())
        {
            Vehicle nextVehicle = waitingQueue.Dequeue();
            roundabout.AddVehicle(nextVehicle);
            Console.WriteLine("Waiting vehicle entered roundabout");
        }
    }

    // PRINT CURRENT ROUNDABOUT STATE
    public void PrintRoundabout()
    {
        roundabout.DisplayRoundabout();
    }

    // PRINT WAITING QUEUE
    public void PrintWaitingQueue()
    {
        waitingQueue.DisplayQueue();
    }
}
