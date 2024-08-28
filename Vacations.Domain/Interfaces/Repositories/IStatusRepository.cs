using Vacations.Domain.Dtos.Entities;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IStatusRepository
{
    Task<StatusDto> GetById(int id);
    Task<StatusDto> GetActiveById(int id);
    Task<StatusDto> Create(StatusDto status);
    Task DeactivateStatus(StatusDto status);
}