using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.UseCases;

public class GetEmployeesUseCase(AppDbContext context) : IGetEmployees
{
    public async Task<List<EmployeeDto>?> GetEmployees()
    {
        var employees = await context.Employess
            .Join(
                context.Departments,
                e => e.DepartmentId,
                d => d.Id,
                (e, d) => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.FirstName + " " + e.LastName,
                    HireDate = e.HireDate,
                    Phone = e.Phone,
                    Address = e.Address,
                    DepartmentName = d.DepartmentName
                })
            .ToListAsync();
        
        return employees;
    }
}