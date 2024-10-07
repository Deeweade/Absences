using Vacations.Domain.Dtos.Entities;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IEmployeeStatusesRepository
{
    Task<EmployeeStatusDto> GetById(int id);
    Task<EmployeeStatusDto> GetLastStatus(int employeeTabNumber);
    Task<EmployeeStatusDto> Create(EmployeeStatusDto status);
    void DeactivateStatus(EmployeeStatusDto status);
    EmployeeStatusDto Update(EmployeeStatusDto status);
    EmployeeStatusDto CloseStatus(EmployeeStatusDto status);
}