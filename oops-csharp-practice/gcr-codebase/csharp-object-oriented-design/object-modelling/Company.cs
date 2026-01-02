using System;
using System.Collections.Generic;

class Employee
{
    public string Name;
    public string Role;

    public Employee(string name, string role)
    {
        Name = name;
        Role = role;
    }

    public void DisplayEmployee()
    {
        Console.WriteLine($"    Employee: {Name}, Role: {Role}");
    }
}

class Department
{
    public string DepartmentName;
    private List<Employee> employees;

    public Department(string name)
    {
        DepartmentName = name;
        employees = new List<Employee>();
    }

    public void AddEmployee(string name, string role)
    {
        employees.Add(new Employee(name, role));
    }

    public void DisplayDepartment()
    {
        Console.WriteLine($"  Department: {DepartmentName}");
        foreach (Employee emp in employees)
        {
            emp.DisplayEmployee();
        }
    }

    // Called when company is destroyed
    public void ClearDepartment()
    {
        employees.Clear();
    }
}

class Company
{
    public string CompanyName;
    private List<Department> departments;

    public Company(string name)
    {
        CompanyName = name;
        departments = new List<Department>();
    }

    public void AddDepartment(string deptName)
    {
        departments.Add(new Department(deptName));
    }

    public Department GetDepartment(string deptName)
    {
        foreach (Department dept in departments)
        {
            if (dept.DepartmentName == deptName)
                return dept;
        }
        return null;
    }

    public void DisplayCompany()
    {
        Console.WriteLine($"Company: {CompanyName}");
        foreach (Department dept in departments)
        {
            dept.DisplayDepartment();
        }
    }

    // Simulating deletion of Company
    public void CloseCompany()
    {
        foreach (Department dept in departments)
        {
            dept.ClearDepartment();
        }

        departments.Clear();
        Console.WriteLine("\nCompany closed. All departments and employees removed.");
    }
}

class Program
{
    static void Main()
    {
        Company company = new Company("TechNova");

        company.AddDepartment("Development");
        company.AddDepartment("HR");

        company.GetDepartment("Development")?.AddEmployee("Rahul", "Software Engineer");
        company.GetDepartment("Development")?.AddEmployee("Anita", "Backend Developer");

        company.GetDepartment("HR")?.AddEmployee("Neha", "HR Manager");

        company.DisplayCompany();

        // Composition effect
        company.CloseCompany();
    }
}
