using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Models.Filters;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IVacationRepository
{
    Task<VacationDto> Create(VacationDto vacationDto);
    Task<IEnumerable<VacationDto>> GetByFilter(VacationFilterDto filter);
}