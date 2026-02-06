namespace RailwayReservation{
public class NormalPassenger : Passenger
{
    public NormalPassenger(int pnr, int age, string name)
        : base(pnr, age, name) { }

    public override double CalculateFare(double baseFare)
    {
        return baseFare;
    }
}
}