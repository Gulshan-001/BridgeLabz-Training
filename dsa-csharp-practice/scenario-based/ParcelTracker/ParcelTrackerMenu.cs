using System;

public class ParcelTrackerMenu
{
    private IParcelTracker tracker;

    public ParcelTrackerMenu()
    {
        tracker = new ParcelTrackerImpl();
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Parcel Tracker Menu ---");
            Console.WriteLine("1. Add Stage");
            Console.WriteLine("2. Add Checkpoint After Stage");
            Console.WriteLine("3. Display Tracking");
            Console.WriteLine("4. Remove Stage (Lost Parcel)");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter stage name: ");
                    tracker.AddStage(Console.ReadLine());
                    break;

                case 2:
                    Console.Write("Enter existing stage: ");
                    string existing = Console.ReadLine();
                    Console.Write("Enter new checkpoint: ");
                    string checkpoint = Console.ReadLine();
                    tracker.AddCheckpointAfter(existing, checkpoint);
                    break;

                case 3:
                    tracker.DisplayTracking();
                    break;

                case 4:
                    Console.Write("Enter stage to remove: ");
                    tracker.RemoveStage(Console.ReadLine());
                    break;

                case 5:
                    return;
            }
        }
    }
}
