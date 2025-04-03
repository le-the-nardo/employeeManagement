using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces.Employee;

public interface IGetEmployeeById
{
    public Task<EmployeeDto?> GetEmployeeById(Guid id);
}