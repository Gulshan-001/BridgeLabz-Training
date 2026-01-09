// Cardio workout class
class CardioWorkout : Workout
{
    public int CaloriesBurned { get; set; }

    public CardioWorkout(string name, int duration, int calories)
        : base(name, duration)
    {
        CaloriesBurned = calories;
    }

    public override void Track()
    {
        Console.WriteLine($"Cardio: {Name}, Duration: {Duration} mins, Calories: {CaloriesBurned}");
    }
}
