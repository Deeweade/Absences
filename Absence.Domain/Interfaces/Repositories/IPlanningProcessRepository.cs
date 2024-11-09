using Absence.Domain.Dtos.Entities;

namespace Absence.Domain.Interfaces.Repositories;

public interface IPlanningProcessRepository
{
    Task<PlanningProcessDto> GetActive();
}