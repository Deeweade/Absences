using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Dtos.Queries;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IVacationRepository
{
    Task<VacationDto> GetById(int id);
    Task<VacationDto> Create(VacationDto vacationDto);
    Task<IEnumerable<VacationDto>> GetByQuery(VacationQueryDto query);
}