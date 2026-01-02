using System;

class EmployeeManagement


{
    // Static variable shared by all employees
    public static string CompanyName = "Tech Solutions Pvt Ltd";

    static int totalEmployees = 0;

    public string Name;
    public readonly int Id;
    public string Designation;

    public EmployeeManagement(string name, int id, string designation)
    {
        // Using this to assign constructor values to object fields
        this.Name = name;
        this.Id = id;
        this.Designation = designation;

        // Increase count whenever a new employee is created
        totalEmployees++;
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("Company: " + CompanyName);
        Console.WriteLine("Employee Name: " + Name);
        Console.WriteLine("Employee ID: " + Id);
        Console.WriteLine("Designation: " + Designation);
    }

    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + totalEmployees);
    }
}

class Program
{
    static void Main()
    {
        EmployeeManagement emp1 = new EmployeeManagement("Gulshan", 101, "Software Developer");
        EmployeeManagement emp2 = new EmployeeManagement("Amit", 102, "QA Engineer");

        Console.WriteLine("Checking object type before display:");

        // Using is operator for safe type checking
        if (emp1 is EmployeeManagement)
        {
            emp1.DisplayEmployeeDetails();
        }

        Console.WriteLine();

        if (emp2 is Employee)
        {
            emp2.DisplayEmployeeDetails();
        }

        Console.WriteLine();

        // Calling static method using class name
        Employee.DisplayTotalEmployees();
    }
}
