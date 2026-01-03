using System;

// Superclass
class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void DisplayRole()
    {
        Console.WriteLine("Person in school");
    }
}

// Teacher class
class Teacher : Person
{
    public string Subject;

    public Teacher(string name, int age, string subject)
        : base(name, age)
    {
        Subject = subject;
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Teacher");
        Console.WriteLine("Subject: " + Subject);
    }
}

// Student class
class Student : Person
{
    public string Grade;

    public Student(string name, int age, string grade)
        : base(name, age)
    {
        Grade = grade;
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Student");
        Console.WriteLine("Grade: " + Grade);
    }
}

// Staff class
class Staff : Person
{
    public string Department;

    public Staff(string name, int age, string department)
        : base(name, age)
    {
        Department = department;
    }

    public override void DisplayRole()
    {
        Console.WriteLine("Role: Staff");
        Console.WriteLine("Department: " + Department);
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Teacher("Mr. Sharma", 40, "Maths");
        Person p2 = new Student("Aman", 16, "10th");
        Person p3 = new Staff("Ramesh", 45, "Administration");

        p1.DisplayRole();
        Console.WriteLine();

        p2.DisplayRole();
        Console.WriteLine();

        p3.DisplayRole();
    }
}
