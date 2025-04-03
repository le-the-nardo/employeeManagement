using EmployeeManagement.Application.Models;

namespace EmployeeManagement.Application.Interfaces;

public interface IPostEmployee
{
    public Task<bool> PostEmployee(AddEmployeeRequest request);
}