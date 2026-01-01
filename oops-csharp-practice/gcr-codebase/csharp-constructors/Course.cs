using System;

class Course
{
    string courseName;
    int duration;
    double fee;

    static string instituteName = "BridgeLabz";

    public Course(string name, int months, double courseFee)
    {
        courseName = name;
        duration = months;
        fee = courseFee;
    }

    public void DisplayCourseDetails()
    {
        Console.WriteLine("Institute: " + instituteName);
        Console.WriteLine("Course Name: " + courseName);
        Console.WriteLine("Duration (months): " + duration);
        Console.WriteLine("Fee: " + fee);
    }

    public static void UpdateInstituteName(string newName)
    {
        // One change updates institute name for all courses
        instituteName = newName;
    }
}

class Program
{
    static void Main()
    {
        Course c1 = new Course("C# Full Stack", 6, 75000);
        Course c2 = new Course("Java Backend", 5, 68000);

        Console.WriteLine("Before Institute Update:");
        c1.DisplayCourseDetails();
        Console.WriteLine();
        c2.DisplayCourseDetails();

        Console.WriteLine();

        // Updating institute name for all courses
        Course.UpdateInstituteName("BridgeLabz Solutions");

        Console.WriteLine("After Institute Update:");
        c1.DisplayCourseDetails();
        Console.WriteLine();
        c2.DisplayCourseDetails();
    }
}
