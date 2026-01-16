class Vehicle
{
    public int VehicleId { get; private set; }
    public string VehicleNumber { get; private set; }

    public Vehicle(int vehicleId, string vehicleNumber)
    {
        VehicleId = vehicleId;
        VehicleNumber = vehicleNumber;
    }
}
