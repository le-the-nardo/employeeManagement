using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces;

public interface IGetEmployeeById
{
    public Task<EmployeeDto> GetEmployeeById(Guid id);
}