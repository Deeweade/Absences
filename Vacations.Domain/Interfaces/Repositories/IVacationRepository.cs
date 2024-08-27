using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Dtos.Filters;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IVacationRepository
{
    Task<VacationDto> GetById(int id);
    Task<VacationDto> Create(VacationDto vacationDto);
    Task<IEnumerable<VacationDto>> GetByFilter(VacationFilterDto filter);
}