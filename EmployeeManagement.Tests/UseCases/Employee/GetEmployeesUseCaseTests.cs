using EmployeeManagement.Application.UseCases.Employee;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Configuration;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Tests.UseCases.Employee;

[TestClass]
public class GetEmployeesUseCaseTests
{
    private GetEmployeesUseCase _sut;
    private AppDbContext _fakeDbContext;

    [TestInitialize]
    public async Task Setup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDatabase").Options;

        _fakeDbContext = new AppDbContext(options);
        
        await _fakeDbContext.Departments.AddRangeAsync(new List<Department>
        {
            new Department("IT"),
            new Department("HR")
        });

        await _fakeDbContext.SaveChangesAsync();

        var departmentId = _fakeDbContext.Departments.FirstOrDefault()!.Id;
        await _fakeDbContext.Employess.AddRangeAsync(new List<Domain.Entities.Employee>
        {
            new Domain.Entities.Employee("Leonardo", "Silva", departmentId, "123456789", "Rua A" ),
            new Domain.Entities.Employee("Ana", "Souza", departmentId, "5345435", "Rua B" ),
        });
        
        await _fakeDbContext.SaveChangesAsync();

        _sut = new GetEmployeesUseCase(_fakeDbContext);
    }
    
    [TestMethod]
    public async Task GetEmployees_ShouldReturn_EmployeesWithDepartments()
    {
        // Act
        var result = await _sut.GetEmployees();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        
        result.First().DepartmentName.Should().Be(result.Last().DepartmentName);
    }
    
    [TestMethod]
    public async Task GetEmployees_ShouldReturn_EmptyList_WhenNoEmployeesExist()
    {
        // Arrange
        _fakeDbContext.Employess.RemoveRange(_fakeDbContext.Employess);
        await _fakeDbContext.SaveChangesAsync();

        // Act
        var result = await _sut.GetEmployees();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}