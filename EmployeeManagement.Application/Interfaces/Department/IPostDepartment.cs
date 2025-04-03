using EmployeeManagement.Application.Models;

namespace EmployeeManagement.Application.Interfaces.Department;

public interface IPostDepartment
{
    public Task<bool> PostDepartment(AddDepartmentRequest request);
}