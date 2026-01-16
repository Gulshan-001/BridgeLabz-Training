using System;

class TrafficManagerMenu
{
    private ITrafficManagerOperations trafficManager;

    public TrafficManagerMenu()
    {
        trafficManager = new TrafficManagerUtilityImpl();
    }

    public void Start()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== TRAFFIC MANAGER MENU =====");
            Console.WriteLine("1. Add Vehicle to Roundabout");
            Console.WriteLine("2. Remove Vehicle from Roundabout");
            Console.WriteLine("3. Show Roundabout State");
            Console.WriteLine("4. Show Waiting Queue");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddVehicleFlow();
                    break;

                case 2:
                    RemoveVehicleFlow();
                    break;

                case 3:
                    trafficManager.PrintRoundabout();
                    break;

                case 4:
                    trafficManager.PrintWaitingQueue();
                    break;

                case 0:
                    Console.WriteLine("Exiting Traffic Manager...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 0);
    }

    // -------- MENU FLOWS --------

    private void AddVehicleFlow()
    {
        Console.Write("Enter Vehicle ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Vehicle Number: ");
        string number = Console.ReadLine();

        Vehicle vehicle = new Vehicle(id, number);
        trafficManager.EnterRoundabout(vehicle);
    }

    private void RemoveVehicleFlow()
    {
        Console.Write("Enter Vehicle ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        trafficManager.ExitRoundabout(id);
    }
}
