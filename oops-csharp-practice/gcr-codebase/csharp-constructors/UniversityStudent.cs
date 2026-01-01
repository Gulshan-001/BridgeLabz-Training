using System;

class UniversityStudent
{
    public int rollNumber;
    protected string name;
    private double cgpa;

    public UniversityStudent(int roll, string studentName, double studentCgpa)
    {
        rollNumber = roll;
        name = studentName;
        cgpa = studentCgpa;
    }

    public void SetCGPA(double newCgpa)
    {
        // CGPA is private, so it can only be changed using this method
        cgpa = newCgpa;
    }

    public double GetCGPA()
    {
        // Gives controlled access to CGPA
        return cgpa;
    }

    public void DisplayStudent()
    {
        Console.WriteLine("Roll Number: " + rollNumber);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("CGPA: " + cgpa);
    }
}

class PostgraduateStudent : UniversityStudent
{
    string specialization;

    public PostgraduateStudent(int roll, string studentName, double studentCgpa, string spec)
        : base(roll, studentName, studentCgpa)
    {
        specialization = spec;
    }

    public void DisplayPostgraduateStudent()
    {
        Console.WriteLine("Roll Number: " + rollNumber);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Specialization: " + specialization);
        Console.WriteLine("CGPA: " + GetCGPA());
    }
}

class Program
{
    static void Main()
    {
        PostgraduateStudent pgStudent =
            new PostgraduateStudent(101, "Gulshan", 8.6, "Computer Science");

        pgStudent.DisplayPostgraduateStudent();

        Console.WriteLine();

        // Updating CGPA using public method
        pgStudent.SetCGPA(9.1);
        Console.WriteLine("After CGPA Update:");
        pgStudent.DisplayPostgraduateStudent();
    }
}
