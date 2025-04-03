using EmployeeManagement.Application.Models;

namespace EmployeeManagement.Application.Interfaces.Employee;

public interface IPutEmployee
{
    public Task<bool> UpdateEmployee(Guid id, UpdateEmployeeRequest request);
}