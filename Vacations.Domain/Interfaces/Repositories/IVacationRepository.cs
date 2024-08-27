using Vacations.Domain.Dtos.Entities;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IVacationRepository
{
    Task<VacationDto> Create(VacationDto vacationDto);
}