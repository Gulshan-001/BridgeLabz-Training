class QueueNode
{
    public Vehicle Data;        // vehicle waiting to enter
    public QueueNode Next;      // next vehicle in queue

    public QueueNode(Vehicle vehicle)
    {
        Data = vehicle;
        Next = null;
    }
}
