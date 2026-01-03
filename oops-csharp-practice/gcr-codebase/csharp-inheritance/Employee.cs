using System;

// Base class
class Employee
{
    public string Name;
    public int Id;
    public double Salary;

    public Employee(string name, int id, double salary)
    {
        Name = name;
        Id = id;
        Salary = salary;
    }

    // Base method
    public virtual void DisplayDetails()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Salary: " + Salary);
    }
}

// Manager class
class Manager : Employee
{
    public int TeamSize;

    public Manager(string name, int id, double salary, int teamSize)
        : base(name, id, salary)
    {
        TeamSize = teamSize;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Manager Details");
        base.DisplayDetails();
        Console.WriteLine("Team Size: " + TeamSize);
    }
}

// Developer class
class Developer : Employee
{
    public string ProgrammingLanguage;

    public Developer(string name, int id, double salary, string language)
        : base(name, id, salary)
    {
        ProgrammingLanguage = language;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Developer Details");
        base.DisplayDetails();
        Console.WriteLine("Language: " + ProgrammingLanguage);
    }
}

// Intern class
class Intern : Employee
{
    public string InternshipDuration;

    public Intern(string name, int id, double salary, string duration)
        : base(name, id, salary)
    {
        InternshipDuration = duration;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Intern Details");
        base.DisplayDetails();
        Console.WriteLine("Duration: " + InternshipDuration);
    }
}

class Program
{
    static void Main()
    {
        Employee e1 = new Manager("Amit", 101, 60000, 8);
        Employee e2 = new Developer("Riya", 102, 50000, "C#");
        Employee e3 = new Intern("Kunal", 103, 15000, "6 Months");

        e1.DisplayDetails();
        Console.WriteLine();

        e2.DisplayDetails();
        Console.WriteLine();

        e3.DisplayDetails();
    }
}