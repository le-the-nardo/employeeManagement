using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.UseCases;

public class GetEmployeesUseCase(AppDbContext context) : IGetEmployees
{
    public async Task<List<EmployeeDto>> GetEmployees()
    {
        var employees = await context.Employess.ToListAsync();
        var departments = await context.Departments.ToListAsync();
        var result = employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            Name = e.FirstName + " " + e.LastName,
            HireDate = e.HireDate,
            Phone = e.Phone,
            Address = e.Address,
            DepartmentName = departments.Find(d => d.Id == e.DepartmentId)!.DepartmentName
        }).ToList();
        return result;
    }
}