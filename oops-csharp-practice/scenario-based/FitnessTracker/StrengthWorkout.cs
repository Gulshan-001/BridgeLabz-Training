// Strength workout class
class StrengthWorkout : Workout
{
    public int Sets { get; set; }

    public StrengthWorkout(string name, int duration, int sets)
        : base(name, duration)
    {
        Sets = sets;
    }

    public override void Track()
    {
        Console.WriteLine($"Strength: {Name}, Duration: {Duration} mins, Sets: {Sets}");
    }
}
