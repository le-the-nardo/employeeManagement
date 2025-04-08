namespace EmployeeManagement.Application.DTOs;

public class EmployeeDto
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public Guid DepartmentId { get; init; }
}