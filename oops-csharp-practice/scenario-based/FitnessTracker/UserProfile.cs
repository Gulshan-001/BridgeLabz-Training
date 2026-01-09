using System;
using System.Collections.Generic;

// User profile containing workouts
class UserProfile
{
    public string Username { get; set; }
    private List<Workout> workouts = new List<Workout>();

    public UserProfile(string username)
    {
        Username = username;
    }

    public void AddWorkout(Workout workout)
    {
        workouts.Add(workout);
    }

    public void ShowWorkouts()
    {
        Console.WriteLine($"Workout History for {Username}:");
        foreach (Workout w in workouts)
        {
            w.Track();
        }
    }
}
