using EmployeeManagement.Application.Models;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Controllers;

public static class DepartmentController
{
    public static void AddDepartmentsRoutes(this WebApplication app)
    {
        var departmentRoutes = app.MapGroup("department");

        departmentRoutes.MapGet("all", async (AppDbContext context) =>
        {
            var a = 10;
            var departments = await context.Departments.ToListAsync();
            return departments;
        });

        departmentRoutes.MapPost("", async (AddDepartmentRequest request, AppDbContext context) =>
        {
            var newDepartment = new Department(request.DepartmentName);

            await context.Departments.AddAsync(newDepartment);
            await context.SaveChangesAsync();

        });
    }
}