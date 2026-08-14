using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace EmployeePayroll.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeeService.GetAllEmployees();

        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);

        if (employee == null)
        {
            return NotFound($"Employee with ID {id} not found.");
        }

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(
        EmployeeRequestDTO employee)
    {
        var createdEmployee =
            await _employeeService.AddEmployee(employee);

        return CreatedAtAction(
            nameof(GetEmployeeById),
            new { id = createdEmployee.Id },
            createdEmployee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(
        int id,
        EmployeeRequestDTO employee)
    {
        var updatedEmployee =
            await _employeeService.UpdateEmployee(id, employee);

        if (updatedEmployee == null)
        {
            return NotFound($"Employee with ID {id} not found.");
        }

        return Ok(updatedEmployee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var deleted = await _employeeService.DeleteEmployee(id);

        if (!deleted)
        {
            return NotFound($"Employee with ID {id} not found.");
        }

        return Ok("Employee deleted successfully.");
    }
}