using Models.Entity;

namespace Repository.Interface;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployees();

    Task<Employee?> GetEmployeeById(int id);

    Task<Employee> AddEmployee(Employee employee);

    Task<Employee?> UpdateEmployee(Employee employee);

    Task<bool> DeleteEmployee(int id);
}