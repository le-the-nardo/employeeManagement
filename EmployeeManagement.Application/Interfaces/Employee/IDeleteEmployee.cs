namespace EmployeeManagement.Application.Interfaces.Employee;

public interface IDeleteEmployee
{
    public Task<bool> DeleteEmployee(Guid id);
}