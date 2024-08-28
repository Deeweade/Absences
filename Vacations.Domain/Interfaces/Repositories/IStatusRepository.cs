using Vacations.Domain.Dtos.Entities;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IStatusRepository
{
    Task<StatusDto> ChangeStatus(StatusDto status);
}