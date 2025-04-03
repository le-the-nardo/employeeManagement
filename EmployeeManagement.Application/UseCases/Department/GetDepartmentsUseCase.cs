using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces.Department;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.UseCases.Department;

public class GetDepartmentsUseCase(AppDbContext context) : IGetDepartments
{
    public async Task<List<DepartmentDto>?> GetDepartments()
    {
        var departments = await context.Departments
            .Select(d=> new DepartmentDto
                {
                    Id = d.Id,
                    DepartmentName = d.DepartmentName
                })
            .ToListAsync();

        return departments.Count != 0 ? departments : null;
    }
}