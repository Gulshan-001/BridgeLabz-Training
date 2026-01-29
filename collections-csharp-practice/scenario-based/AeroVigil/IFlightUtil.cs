public interface IFlightUtil
{
    bool validateFlightNumber(string flightNumber);
    bool validateFlightName(string flightName);
    bool validatePassengerCount(int passengerCount, string flightName);
    double calculateFuelToFillTank(string flightName, double currentFuelLevel);
}
