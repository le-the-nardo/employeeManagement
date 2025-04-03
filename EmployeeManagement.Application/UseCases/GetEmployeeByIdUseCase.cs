using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.UseCases;

public class GetEmployeeByIdUseCase(AppDbContext context) : IGetEmployeeById
{
    public async Task<EmployeeDto> GetEmployeeById(Guid id)
    {
        var employees = await context.Employess.ToListAsync();
        var departments = await context.Departments.ToListAsync();
        var employee = employees.FirstOrDefault(e => e.Id == id);
        
        var result =  new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.FirstName + " " + employee.LastName,
            HireDate = employee.HireDate,
            Phone = employee.Phone,
            Address = employee.Address,
            DepartmentName = departments.Find(d => d.Id == employee.DepartmentId)!.DepartmentName
        };
        return result;
    }
}