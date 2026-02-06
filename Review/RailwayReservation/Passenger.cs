public abstract class Passenger
{
    public int Pnr{get; private set;}
    public int Age{get; private set;}
    public string Name{get; private set;}

    public Passenger(int pnr, int age, string name)
    {
        Pnr=pnr;
        Age=age;
        Name=name;
    }
    public abstract double CalculateFare(double baseFare);
}