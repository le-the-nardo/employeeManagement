using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces.Department;

public interface IGetDepartments
{
    public Task<List<DepartmentDto>?> GetDepartments();
}