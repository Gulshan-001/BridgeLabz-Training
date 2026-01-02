using System;
using System.Collections.Generic;

class Course
{
    public string CourseName;
    public Professor AssignedProfessor;
    private List<Student> enrolledStudents;

    public Course(string name)
    {
        CourseName = name;
        enrolledStudents = new List<Student>();
    }

    public void EnrollStudent(Student student)
    {
        enrolledStudents.Add(student);
        student.AddCourse(this);
    }

    public void AssignProfessor(Professor professor)
    {
        AssignedProfessor = professor;
        professor.AddCourse(this);
    }

    public void ShowCourseDetails()
    {
        Console.WriteLine($"\nCourse: {CourseName}");
        if (AssignedProfessor != null)
            Console.WriteLine($"Taught by: {AssignedProfessor.Name}");
        else
            Console.WriteLine("No professor assigned yet.");

        Console.WriteLine("Enrolled Students:");
        foreach (Student s in enrolledStudents)
        {
            Console.WriteLine($"- {s.Name}");
        }
    }
}

class Student
{
    public string Name;
    private List<Course> courses;

    public Student(string name)
    {
        Name = name;
        courses = new List<Course>();
    }

    public void AddCourse(Course course)
    {
        courses.Add(course);
    }

    public void ViewCourses()
    {
        Console.WriteLine($"\nCourses of {Name}:");
        foreach (Course c in courses)
        {
            Console.WriteLine($"- {c.CourseName}");
        }
    }
}

class Professor
{
    public string Name;
    private List<Course> courses;

    public Professor(string name)
    {
        Name = name;
        courses = new List<Course>();
    }

    public void AddCourse(Course course)
    {
        courses.Add(course);
    }

    public void ViewCourses()
    {
        Console.WriteLine($"\nCourses taught by {Name}:");
        foreach (Course c in courses)
        {
            Console.WriteLine($"- {c.CourseName}");
        }
    }
}

class University
{
    public string Name;
    private List<Student> students;
    private List<Professor> professors;

    public University(string name)
    {
        Name = name;
        students = new List<Student>();
        professors = new List<Professor>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void AddProfessor(Professor professor)
    {
        professors.Add(professor);
    }

    public void ShowUniversity()
    {
        Console.WriteLine($"\nUniversity: {Name}");
        Console.WriteLine("Students:");
        foreach (Student s in students)
        {
            Console.WriteLine($"- {s.Name}");
        }
        Console.WriteLine("Professors:");
        foreach (Professor p in professors)
        {
            Console.WriteLine($"- {p.Name}");
        }
    }
}

class Program
{
    static void Main()
    {
        // University
        University uni = new University("Global University");

        // Students
        Student alice = new Student("Alice");
        Student bob = new Student("Bob");
        uni.AddStudent(alice);
        uni.AddStudent(bob);

        // Professors
        Professor profSmith = new Professor("Dr. Smith");
        Professor profJones = new Professor("Dr. Jones");
        uni.AddProfessor(profSmith);
        uni.AddProfessor(profJones);

        // Courses
        Course maths = new Course("Mathematics");
        Course physics = new Course("Physics");

        // Assign Professors
        maths.AssignProfessor(profSmith);
        physics.AssignProfessor(profJones);

        // Enroll Students
        maths.EnrollStudent(alice);
        maths.EnrollStudent(bob);
        physics.EnrollStudent(alice);

        // Display
        uni.ShowUniversity();
        alice.ViewCourses();
        bob.ViewCourses();
        profSmith.ViewCourses();
        profJones.ViewCourses();
        maths.ShowCourseDetails();
        physics.ShowCourseDetails();
    }
}
