using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces.Employee;

public interface IGetEmployees
{
    public Task<List<EmployeeDto>?> GetEmployees();
}