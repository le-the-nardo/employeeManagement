using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.UseCases;

public class GetEmployeeByIdUseCase(AppDbContext context) : IGetEmployeeById
{
    public async Task<EmployeeDto?> GetEmployeeById(Guid id)
    {
        var employee = await context.Employess
            .Where(e => e.Id == id)
            .Join(context.Departments, e => e.DepartmentId, d => d.Id,
                (e,d) => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.FirstName + " " + e.LastName,
                    HireDate = e.HireDate,
                    Phone = e.Phone,
                    Address = e.Address,
                    DepartmentName = d.DepartmentName
                }).FirstOrDefaultAsync();

        return employee;
    }
}