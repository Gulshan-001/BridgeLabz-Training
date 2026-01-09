// Abstract base class for all workouts
abstract class Workout : ITrackable
{
    public string Name { get; set; }
    public int Duration { get; set; } // in minutes

    public Workout(string name, int duration)
    {
        Name = name;
        Duration = duration;
    }

    public abstract void Track();
}
