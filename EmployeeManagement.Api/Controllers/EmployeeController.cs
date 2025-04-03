using EmployeeManagement.Application.Interfaces.Employee;
using EmployeeManagement.Application.Models;

namespace EmployeeManagement.Api.Controllers;

public static class EmployeeController
{
    public static void AddEmployeeRoutes(this WebApplication app)
    {
        var employeeRoutes = app.MapGroup("employee");

        employeeRoutes.MapPost("", async (AddEmployeeRequest request, IPostEmployee useCase) =>
        {
            var employeePersisted = await useCase.PostEmployee(request);

            return employeePersisted ? Results.Ok("Employee created") : Results.BadRequest("Error to create employee.");
        });

        employeeRoutes.MapGet("all", async (IGetEmployees useCase) =>
        {
            var employees = await useCase.GetEmployees();
            
            return employees != null ? Results.Ok(employees) : Results.NotFound("No employees found.");
        });

        employeeRoutes.MapGet("{id:guid}", async (Guid id, IGetEmployeeById useCase) =>
        {
            var employee = await useCase.GetEmployeeById(id);

            return employee != null ? Results.Ok(employee) : Results.NotFound("Employee not found.");
        });

        employeeRoutes.MapPut("{id:guid}", async (Guid id, UpdateEmployeeRequest request, IPutEmployee useCase) =>
        {
            var employeeUpdated = await useCase.UpdateEmployee(id, request);
            
            return employeeUpdated ? Results.Ok("Employee updated successfully.") : Results.BadRequest("Error to update employee.");
        });

        employeeRoutes.MapDelete("{id:guid}", async (Guid id, IDeleteEmployee useCase) =>
        {
            var employeeDeleted = await useCase.DeleteEmployee(id);

            return employeeDeleted ? Results.Ok($"Employee Id '{id}' removed successfully") : Results.NotFound($"Employee Id '{id}' not found.");
        });
    }
}