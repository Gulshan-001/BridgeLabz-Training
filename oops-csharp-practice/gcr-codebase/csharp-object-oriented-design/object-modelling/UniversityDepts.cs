using System;
using System.Collections.Generic;

class Faculty
{
    public string Name;
    public string Subject;

    // Faculty exists independently
    public Faculty(string name, string subject)
    {
        Name = name;
        Subject = subject;
    }

    public void DisplayFaculty()
    {
        Console.WriteLine($"Faculty: {Name}, Subject: {Subject}");
    }
}

class Department
{
    public string DepartmentName;

    public Department(string name)
    {
        DepartmentName = name;
    }

    public void DisplayDepartment()
    {
        Console.WriteLine($"Department: {DepartmentName}");
    }
}

class University
{
    public string UniversityName;

    // Composition
    private List<Department> departments;

    // Aggregation
    private List<Faculty> faculties;

    public University(string name)
    {
        UniversityName = name;
        departments = new List<Department>();
        faculties = new List<Faculty>();
    }

    public void AddDepartment(string deptName)
    {
        departments.Add(new Department(deptName));
    }

    public void AddFaculty(Faculty faculty)
    {
        faculties.Add(faculty);
    }

    public void DisplayUniversity()
    {
        Console.WriteLine($"University: {UniversityName}");

        Console.WriteLine("\nDepartments:");
        foreach (Department d in departments)
        {
            d.DisplayDepartment();
        }

        Console.WriteLine("\nFaculty Members:");
        foreach (Faculty f in faculties)
        {
            f.DisplayFaculty();
        }
    }

    // Simulating deletion of University
    public void CloseUniversity()
    {
        departments.Clear();   // departments destroyed
        Console.WriteLine("\nUniversity closed. All departments removed.");
    }
}

class Program
{
    static void Main()
    {
        // Faculty created independently
        Faculty profA = new Faculty("Dr. Sharma", "Physics");
        Faculty profB = new Faculty("Dr. Mehta", "Mathematics");

        // University
        University uni = new University("National University");

        // Composition: Departments belong to University
        uni.AddDepartment("Science");
        uni.AddDepartment("Engineering");

        // Aggregation: Faculty added, but not owned
        uni.AddFaculty(profA);
        uni.AddFaculty(profB);

        uni.DisplayUniversity();

        // University deletion effect
        uni.CloseUniversity();

        // Faculty still exists
        Console.WriteLine("\nFaculty still exists after university closure:");
        profA.DisplayFaculty();
        profB.DisplayFaculty();
    }
}
