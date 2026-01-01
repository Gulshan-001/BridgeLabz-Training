using System;

class Employee
{
    // Attributes
    public string Name;
    public int Id;
    public double Salary;

    // Method to display details
    public void DisplayDetails()
    {
        Console.WriteLine("Employee Name: " + Name);
        Console.WriteLine("Employee ID: " + Id);
        Console.WriteLine("Employee Salary: " + Salary);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an Employee object
        Employee emp = new Employee();

        Console.Write("Enter Employee Name: ");
        emp.Name = Console.ReadLine();

        Console.Write("Enter Employee ID: ");
        emp.Id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Salary: ");
        emp.Salary = double.Parse(Console.ReadLine());

        Console.WriteLine("\nEmployee Details:");
        emp.DisplayDetails();
    }
}
