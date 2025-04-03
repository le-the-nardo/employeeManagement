using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.UseCases;

public class PutEmployeeUseCase(AppDbContext context) : IPutEmployee
{
    public async Task<bool> UpdateEmployee(Guid id, UpdateEmployeeRequest request)
    {
        var employee = await context.Employess.SingleOrDefaultAsync(e => e.Id == id);
        var department = await context.Departments.SingleOrDefaultAsync(d => d.Id == request.DepartmentId);

        if (employee == null || department == null)
            return false;
        
        employee.UpdateEmployee(request.FirstName, request.LastName, request.DepartmentId, request.Phone, request.Address);

        await context.SaveChangesAsync();
        return true;
    }
}