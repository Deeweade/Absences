using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Dtos.Queries;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IStatusRepository
{
    Task<StatusDto> GetById(int id);
    Task<StatusDto> GetLastStatus(int employeeTabNumber);
    Task<StatusDto> Create(StatusDto status);
    void DeactivateStatus(StatusDto status);
    void UpdateStatus(StatusDto status);
}