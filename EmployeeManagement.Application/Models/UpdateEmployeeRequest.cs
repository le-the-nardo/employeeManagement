namespace EmployeeManagement.Application.Models;

public record UpdateEmployeeRequest(string FirstName, string LastName, Guid DepartmentId, string Phone, string Address);