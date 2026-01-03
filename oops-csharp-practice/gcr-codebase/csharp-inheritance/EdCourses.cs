using System;

// Base class
class Course
{
    public string CourseName;
    public int Duration; // in weeks

    public Course(string courseName, int duration)
    {
        CourseName = courseName;
        Duration = duration;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Course Name: " + CourseName);
        Console.WriteLine("Duration: " + Duration + " weeks");
    }
}

// First level child
class OnlineCourse : Course
{
    public string Platform;
    public bool IsRecorded;

    public OnlineCourse(string courseName, int duration, string platform, bool isRecorded)
        : base(courseName, duration)
    {
        Platform = platform;
        IsRecorded = isRecorded;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Platform: " + Platform);
        Console.WriteLine("Recorded: " + IsRecorded);
    }
}

// Second level child
class PaidOnlineCourse : OnlineCourse
{
    public double Fee;
    public double Discount;

    public PaidOnlineCourse(string courseName, int duration, string platform, bool isRecorded, double fee, double discount)
        : base(courseName, duration, platform, isRecorded)
    {
        Fee = fee;
        Discount = discount;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Fee: " + Fee);
        Console.WriteLine("Discount: " + Discount + "%");
    }
}

class Program
{
    static void Main()
    {
        PaidOnlineCourse c1 = new PaidOnlineCourse(
            "C# Basics",
            6,
            "Zoom",
            true,
            5000,
            10
        );

        c1.DisplayDetails();
    }
}
