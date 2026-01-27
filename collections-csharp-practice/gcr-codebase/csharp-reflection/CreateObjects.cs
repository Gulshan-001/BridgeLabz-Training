using System;
using System.Reflection;

class Student
{
    public int Id;
    public string Name;

    public Student()
    {
        Id = 1;
        Name = "Default Student";
    }

    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }
}

class Program
{
    static void Main()
    {
        // Get Type information
        Type type = typeof(Student);

        // Create object dynamically (no new keyword)
        object obj = Activator.CreateInstance(type);

        // Cast and use
        Student student = (Student)obj;
        student.Display();
    }
}
