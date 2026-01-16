interface ITrafficManagerOperations
{
    void EnterRoundabout(Vehicle vehicle);
    void ExitRoundabout(int vehicleId);
    void PrintRoundabout();
    void PrintWaitingQueue();
}