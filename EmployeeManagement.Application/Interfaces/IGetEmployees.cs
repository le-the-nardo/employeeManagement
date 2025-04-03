using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces;

public interface IGetEmployees
{
    public Task<List<EmployeeDto>> GetEmployees();
}