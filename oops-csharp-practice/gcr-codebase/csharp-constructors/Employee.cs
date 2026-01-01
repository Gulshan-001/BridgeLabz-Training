using System;

class Employee
{
    public int employeeID;
    protected string department;
    private double salary;

    public Employee(int id, string dept, double initialSalary)
    {
        employeeID = id;
        department = dept;
        salary = initialSalary;
    }

    public void UpdateSalary(double newSalary)
    {
        // Salary is private, so changes go through this method
        if (newSalary > 0)
        {
            salary = newSalary;
        }
    }

    public double GetSalary()
    {
        // Safe way to read salary
        return salary;
    }
}

class Manager : Employee
{
    string designation;

    public Manager(int id, string dept, double salary, string role)
        : base(id, dept, salary)
    {
        designation = role;
    }

    public void DisplayManagerDetails()
    {
        Console.WriteLine("Employee ID: " + employeeID);
        Console.WriteLine("Department: " + department);
        Console.WriteLine("Designation: " + designation);
        Console.WriteLine("Salary: " + GetSalary());
    }
}

class Program
{
    static void Main()
    {
        Manager manager =
            new Manager(501, "IT", 85000, "Project Manager");

        manager.DisplayManagerDetails();

        Console.WriteLine();

        // Updating salary using public method
        manager.UpdateSalary(92000);
        Console.WriteLine("After Salary Update:");
        manager.DisplayManagerDetails();
    }
}
