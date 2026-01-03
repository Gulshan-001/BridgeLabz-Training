using System;

class UniStudent
{
    // Static variable shared by all students
    public static string UniversityName = "Global Tech University";

    static int totalStudents = 0;

    public string Name;
    public readonly int RollNumber;
    public string Grade;
    
    public UniStudent(string name, int rollNumber, string grade)
    {
        // Using this to assign constructor values
        this.Name = name;
        this.RollNumber = rollNumber;
        this.Grade = grade;

        // Increase count when a new student is created
        totalStudents++;
    }

    public void DisplayStudentDetails()
    {
        Console.WriteLine("University: " + UniversityName);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Roll Number: " + RollNumber);
        Console.WriteLine("Grade: " + Grade);
    }

    public void UpdateGrade(string newGrade)
    {
        Grade = newGrade;
    }

    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students Enrolled: " + totalStudents);
    }
}

class Program
{
    static void Main()
    {
        UniStudent s1 = new UniStudent("Gulshan", 201, "A");
        UniStudent s2 = new UniStudent("Amit", 202, "B");

        Console.WriteLine("Checking object type before operations:");

        // Using is operator before performing actions
        if (s1 is UniStudent)
        {
            s1.DisplayStudentDetails();
        }

        Console.WriteLine();

        if (s2 is UniStudent)
        {
            s2.DisplayStudentDetails();
        }

        Console.WriteLine();

        // Updating grade safely
        s1.UpdateGrade("A+");

        Console.WriteLine("After Grade Update:");
        s1.DisplayStudentDetails();

        Console.WriteLine();

        // Display total students using static method
        UniStudent.DisplayTotalStudents();
    }
}
