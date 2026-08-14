using Microsoft.EntityFrameworkCore;
using Models.Entity;
using Repository.Context;
using Repository.Interface;

namespace Repository.Service;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee?> UpdateEmployee(Employee employee)
    {
        var existingEmployee = await _context.Employees.FindAsync(employee.Id);

        if (existingEmployee == null)
        {
            return null;
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Email = employee.Email;
        existingEmployee.Department = employee.Department;
        existingEmployee.Salary = employee.Salary;

        await _context.SaveChangesAsync();

        return existingEmployee;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return false;
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return true;
    }
}