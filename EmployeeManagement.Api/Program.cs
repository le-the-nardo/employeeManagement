using EmployeeManagement.Api.Controllers;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.UseCases;
using EmployeeManagement.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

// UseCases
builder.Services.AddScoped<IGetEmployees, GetEmployeesUseCase>();
builder.Services.AddScoped<IGetEmployeeById, GetEmployeeByIdUseCase>();
builder.Services.AddScoped<IPostEmployee, PostEmployeeUseCase>();
builder.Services.AddScoped<IPutEmployee, PutEmployeeUseCase>();
builder.Services.AddScoped<IDeleteEmployee, DeleteEmployeeUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddEmployeeRoutes();         
app.AddDepartmentsRoutes();      

app.Run();


