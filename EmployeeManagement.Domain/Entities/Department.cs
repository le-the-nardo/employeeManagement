namespace EmployeeManagement.Domain.Entities;

public class Department
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; } = string.Empty;

    public Department(string departmentName)
    {
        Id = Guid.NewGuid();
        DepartmentName = departmentName;
    }
}