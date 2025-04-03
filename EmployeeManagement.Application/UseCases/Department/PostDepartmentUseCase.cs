using EmployeeManagement.Application.Interfaces.Department;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Infrastructure.Configuration;

namespace EmployeeManagement.Application.UseCases.Department;

public class PostDepartmentUseCase(AppDbContext context) : IPostDepartment
{
    public async Task<bool> PostDepartment(AddDepartmentRequest request)
    {
        var newDepartment = new Domain.Entities.Department(request.DepartmentName);

        await context.Departments.AddAsync(newDepartment);
        await context.SaveChangesAsync();

        return true;
    }
}