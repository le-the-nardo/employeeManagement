using EmployeeManagement.Application.Models;

namespace EmployeeManagement.Application.Interfaces.Employee;

public interface IPostEmployee
{
    public Task<bool> PostEmployee(AddEmployeeRequest request);
}