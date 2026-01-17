class Runners
{
    public string Name { get; private set; }
    public int DistanceRun { get; private set; } // in kilometers
    public Runners(string name, int distanceRun)
    {
        Name = name;
        DistanceRun = distanceRun;
    }
}