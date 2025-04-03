using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.UseCases;

public class DeleteEmployeeUseCase(AppDbContext context) : IDeleteEmployee
{
    public async Task<bool> DeleteEmployee(Guid id)
    {
        var employee = await context.Employess.SingleOrDefaultAsync(e => e.Id == id);

        if (employee == null)
            return false;

        context.Employess.Remove(employee);
        await context.SaveChangesAsync();

        return true;
    }
}