using EmployeeManagement.Application.Interfaces.Department;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Controllers;

public static class DepartmentController
{
    public static void AddDepartmentsRoutes(this WebApplication app)
    {
        var departmentRoutes = app.MapGroup("department");

        departmentRoutes.MapGet("all", async (IGetDepartments useCase) =>
        {
            var departments = await useCase.GetDepartments();

            return departments != null ? Results.Ok(departments) : Results.NotFound("There is no departments registered.");
        });

        departmentRoutes.MapPost("", async (AddDepartmentRequest request, IPostDepartment useCase) =>
        {
            var departmentCreated = await useCase.PostDepartment(request);

            return departmentCreated
                ? Results.Ok("Department created.")
                : Results.BadRequest("Error to create department");
        });
    }
}