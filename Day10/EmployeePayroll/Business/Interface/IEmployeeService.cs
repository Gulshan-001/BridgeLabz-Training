using Models.DTO;

namespace Business.Interface;

public interface IEmployeeService
{
    Task<List<EmployeeResponseDTO>> GetAllEmployees();

    Task<EmployeeResponseDTO?> GetEmployeeById(int id);

    Task<EmployeeResponseDTO> AddEmployee(EmployeeRequestDTO employee);

    Task<EmployeeResponseDTO?> UpdateEmployee(
        int id,
        EmployeeRequestDTO employee);

    Task<bool> DeleteEmployee(int id);
}