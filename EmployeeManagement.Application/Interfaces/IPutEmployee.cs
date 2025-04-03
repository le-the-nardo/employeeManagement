using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Models;

namespace EmployeeManagement.Application.Interfaces;

public interface IPutEmployee
{
    public Task<bool> UpdateEmployee(Guid id, UpdateEmployeeRequest request);
}