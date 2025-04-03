using EmployeeManagement.Application.Interfaces.Employee;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Infrastructure.Configuration;

namespace EmployeeManagement.Application.UseCases.Employee;

public class PostEmployeeUseCase(AppDbContext context) : IPostEmployee
{
    public async Task<bool> PostEmployee(AddEmployeeRequest request)
    {
        var department = context.Departments.FirstOrDefault(d => d.Id == request.DepartmentId);

        if (department == null)
            return false;
        
        var newEmployee = new Domain.Entities.Employee(request.FirstName, request.LastName, request.DepartmentId, request.Phone, request.Address);

        await context.Employess.AddAsync(newEmployee);
        await context.SaveChangesAsync();

        return true;
    }
}