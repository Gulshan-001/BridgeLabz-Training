using System;
using System.Collections.Generic;

class Course
{
    public string CourseName;
    private List<Student> enrolledStudents;

    public Course(string name)
    {
        CourseName = name;
        enrolledStudents = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        enrolledStudents.Add(student);
    }

    public void ShowEnrolledStudents()
    {
        Console.WriteLine($"\nStudents enrolled in {CourseName}:");
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

    public void EnrollCourse(Course course)
    {
        courses.Add(course);
        course.AddStudent(this);   // association both ways
    }

    public void ViewCourses()
    {
        Console.WriteLine($"\nCourses enrolled by {Name}:");
        foreach (Course c in courses)
        {
            Console.WriteLine($"- {c.CourseName}");
        }
    }
}

class School
{
    public string SchoolName;
    private List<Student> students;   // Aggregation

    public School(string name)
    {
        SchoolName = name;
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void ShowStudents()
    {
        Console.WriteLine($"\nStudents in {SchoolName}:");
        foreach (Student s in students)
        {
            Console.WriteLine($"- {s.Name}");
        }
    }
}

class Program
{
    static void Main()
    {
        // School
        School school = new School("Green Valley School");

        // Students (exist independently)
        Student john = new Student("John");
        Student emma = new Student("Emma");

        school.AddStudent(john);
        school.AddStudent(emma);

        // Courses
        Course maths = new Course("Mathematics");
        Course science = new Course("Science");

        // Many-to-many association
        john.EnrollCourse(maths);
        john.EnrollCourse(science);

        emma.EnrollCourse(science);

        // Display
        school.ShowStudents();

        john.ViewCourses();
        emma.ViewCourses();

        maths.ShowEnrolledStudents();
        science.ShowEnrolledStudents();
    }
}
