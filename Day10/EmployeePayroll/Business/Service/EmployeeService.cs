using Business.Interface;
using Models.DTO;
using Models.Entity;
using Repository.Interface;

namespace Business.Service;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<EmployeeResponseDTO>> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllEmployees();

        return employees.Select(employee => new EmployeeResponseDTO
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Department = employee.Department,
            Salary = employee.Salary
        }).ToList();
    }

    public async Task<EmployeeResponseDTO?> GetEmployeeById(int id)
    {
        var employee = await _employeeRepository.GetEmployeeById(id);

        if (employee == null)
        {
            return null;
        }

        return new EmployeeResponseDTO
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Department = employee.Department,
            Salary = employee.Salary
        };
    }

    public async Task<EmployeeResponseDTO> AddEmployee(
        EmployeeRequestDTO employeeDTO)
    {
        var employee = new Employee
        {
            Name = employeeDTO.Name,
            Email = employeeDTO.Email,
            Department = employeeDTO.Department,
            Salary = employeeDTO.Salary
        };

        var addedEmployee = await _employeeRepository.AddEmployee(employee);

        return new EmployeeResponseDTO
        {
            Id = addedEmployee.Id,
            Name = addedEmployee.Name,
            Email = addedEmployee.Email,
            Department = addedEmployee.Department,
            Salary = addedEmployee.Salary
        };
    }

    public async Task<EmployeeResponseDTO?> UpdateEmployee(
        int id,
        EmployeeRequestDTO employeeDTO)
    {
        var employee = new Employee
        {
            Id = id,
            Name = employeeDTO.Name,
            Email = employeeDTO.Email,
            Department = employeeDTO.Department,
            Salary = employeeDTO.Salary
        };

        var updatedEmployee =
            await _employeeRepository.UpdateEmployee(employee);

        if (updatedEmployee == null)
        {
            return null;
        }

        return new EmployeeResponseDTO
        {
            Id = updatedEmployee.Id,
            Name = updatedEmployee.Name,
            Email = updatedEmployee.Email,
            Department = updatedEmployee.Department,
            Salary = updatedEmployee.Salary
        };
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        return await _employeeRepository.DeleteEmployee(id);
    }
}