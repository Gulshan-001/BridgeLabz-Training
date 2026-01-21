using System;
using System.Collections.Generic;

// ---------- BASE COURSE TYPE ----------
abstract class CourseType
{
    public string CourseName { get; protected set; }

    public abstract void Evaluate();
}

// ---------- COURSE TYPES ----------
class ExamCourse : CourseType
{
    public ExamCourse(string name)
    {
        CourseName = name;
    }

    public override void Evaluate()
    {
        Console.WriteLine(CourseName + " evaluated by written exam.");
    }
}

class AssignmentCourse : CourseType
{
    public AssignmentCourse(string name)
    {
        CourseName = name;
    }

    public override void Evaluate()
    {
        Console.WriteLine(CourseName + " evaluated by assignments.");
    }
}

// ---------- GENERIC COURSE MANAGER ----------
class Course<T> where T : CourseType
{
    private List<T> courses = new List<T>();

    public void AddCourse(T course)
    {
        courses.Add(course);
    }

    public void DisplayCourses()
    {
        foreach (T course in courses)
        {
            Console.WriteLine("Course: " + course.CourseName);
            course.Evaluate();
        }
    }
}

// ---------- PROGRAM ----------
class Program
{
    static void Main()
    {
        // Exam-based courses
        Course<ExamCourse> examCourses = new Course<ExamCourse>();
        examCourses.AddCourse(new ExamCourse("Data Structures"));
        examCourses.AddCourse(new ExamCourse("Operating Systems"));

        // Assignment-based courses
        Course<AssignmentCourse> assignmentCourses = new Course<AssignmentCourse>();
        assignmentCourses.AddCourse(new AssignmentCourse("Software Engineering"));
        assignmentCourses.AddCourse(new AssignmentCourse("Web Development"));

        Console.WriteLine("=== Exam Courses ===");
        examCourses.DisplayCourses();

        Console.WriteLine("\n=== Assignment Courses ===");
        assignmentCourses.DisplayCourses();
    }
}
