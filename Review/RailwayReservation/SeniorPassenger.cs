namespace RailwayReservation
{
public class SeniorPassenger : Passenger
{
    public SeniorPassenger(int pnr, int age, string name)
        : base(pnr, age, name) { }

    public override double CalculateFare(double baseFare)
    {
        return baseFare * 0.7; // 30% discount
    }
}
}