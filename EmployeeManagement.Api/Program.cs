using EmployeeManagement.Api.Controllers;
using EmployeeManagement.Application.Interfaces.Department;
using EmployeeManagement.Application.Interfaces.Employee;
using EmployeeManagement.Application.UseCases.Department;
using EmployeeManagement.Application.UseCases.Employee;
using EmployeeManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Frontend
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Banco.sqlite"));

// UseCases
// --- Employee
builder.Services.AddScoped<IGetEmployees, GetEmployeesUseCase>();
builder.Services.AddScoped<IGetEmployeeById, GetEmployeeByIdUseCase>();
builder.Services.AddScoped<IPostEmployee, PostEmployeeUseCase>();
builder.Services.AddScoped<IPutEmployee, PutEmployeeUseCase>();
builder.Services.AddScoped<IDeleteEmployee, DeleteEmployeeUseCase>();
// --- Department
builder.Services.AddScoped<IPostDepartment, PostDepartmentUseCase>();
builder.Services.AddScoped<IGetDepartments, GetDepartmentsUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhostFrontend");

app.AddEmployeeRoutes();         
app.AddDepartmentsRoutes();      

app.Run();


