using System;

public class ParcelTrackerImpl : IParcelTracker
{
    private SinglyLinkedList list;

    public ParcelTrackerImpl()
    {
        list = new SinglyLinkedList();
    }

    public void AddStage(string stageName)
    {
        list.AddLast(stageName);
    }

    public void AddCheckpointAfter(string existingStage, string newStage)
    {
        bool added = list.InsertAfter(existingStage, newStage);
        if (!added)
            Console.WriteLine("Stage not found. Checkpoint not added.");
    }

    public void DisplayTracking()
    {
        list.Display();
    }

    public void RemoveStage(string stageName)
    {
        bool removed = list.Remove(stageName);
        if (!removed)
            Console.WriteLine("Stage not found. Nothing removed.");
    }
}
