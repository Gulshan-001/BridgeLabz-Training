using System;

class Program
{
    static void Main()
    {
        UserProfile user = new UserProfile("Gulshan");

        Workout cardio = new CardioWorkout("Running", 30, 300);
        Workout strength = new StrengthWorkout("Weight Training", 45, 4);

        user.AddWorkout(cardio);
        user.AddWorkout(strength);

        user.ShowWorkouts();
    }
}
