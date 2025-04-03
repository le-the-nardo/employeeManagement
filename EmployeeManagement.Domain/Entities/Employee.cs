namespace EmployeeManagement.Domain.Entities;

public class Employee
{
    public Guid Id { get; init; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public Guid DepartmentId { get; set; }

    public Employee(string firstName, string lastName, Guid departmentId, string phone, string address)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        HireDate = DateTime.Now;
        Phone = phone;
        Address = address;
        DepartmentId = departmentId;
    }

    public void UpdateEmployee(string firstName, string lastName, Guid departmentId, string phone, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        HireDate = DateTime.Now;
        Phone = phone;
        Address = address;
        DepartmentId = departmentId;
    }
}