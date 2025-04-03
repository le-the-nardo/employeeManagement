namespace EmployeeManagement.Application.Interfaces;

public interface IDeleteEmployee
{
    public Task<bool> DeleteEmployee(Guid id);
}