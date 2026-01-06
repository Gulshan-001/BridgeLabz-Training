using System;
using System.Collections.Generic;

// Interface for department work
interface IDepartment
{
    void AssignDepartment(string deptName);
    string GetDepartmentDetails();
}

// Abstract base class
abstract class Employee
{
    // Encapsulation
    private int employeeId;
    private string name;
    protected double baseSalary;

    // Properties
    public int EmployeeId
    {
        get { return employeeId; }
        set { employeeId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Constructor
    public Employee(int id, string name, double salary)
    {
        employeeId = id;
        this.name = name;
        baseSalary = salary;
    }

    // Abstract method
    public abstract double CalculateSalary();

    // Common method
    public void DisplayDetails()
    {
        Console.WriteLine("ID: " + employeeId);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Salary: " + CalculateSalary());
    }
}

// Full-time employee
class FullTimeEmployee : Employee, IDepartment
{
    private string department;

    public FullTimeEmployee(int id, string name, double salary)
        : base(id, name, salary) { }

    public override double CalculateSalary()
    {
        return baseSalary; // fixed salary
    }

    public void AssignDepartment(string deptName)
    {
        department = deptName;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}

// Part-time employee
class PartTimeEmployee : Employee, IDepartment
{
    private int hours;
    private string department;

    public PartTimeEmployee(int id, string name, double hourlyRate, int hours)
        : base(id, name, hourlyRate)
    {
        this.hours = hours;
    }

    public override double CalculateSalary()
    {
        return baseSalary * hours; // hourly salary
    }

    public void AssignDepartment(string deptName)
    {
        department = deptName;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}

class Program
{
    static void Main()
    {
        // Polymorphism
        List<Employee> employees = new List<Employee>();

        FullTimeEmployee emp1 = new FullTimeEmployee(1, "Aman", 40000);
        emp1.AssignDepartment("HR");

        PartTimeEmployee emp2 = new PartTimeEmployee(2, "Riya", 500, 30);
        emp2.AssignDepartment("IT");

        employees.Add(emp1);
        employees.Add(emp2);

        foreach (Employee emp in employees)
        {
            emp.DisplayDetails();
            Console.WriteLine("-------------");
        }
    }
}
