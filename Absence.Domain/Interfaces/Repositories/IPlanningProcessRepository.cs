using Vacations.Domain.Dtos.Entities;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IPlanningProcessRepository
{
    Task<PlanningProcessDto> GetActive();
}