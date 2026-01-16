class RoundaboutNode
{
    public Vehicle Data;          // vehicle inside the roundabout
    public RoundaboutNode Next;   // next vehicle in circular path

    public RoundaboutNode(Vehicle vehicle)
    {
        Data = vehicle;
        Next = null;
    }
}
