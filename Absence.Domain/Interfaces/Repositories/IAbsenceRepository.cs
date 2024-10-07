using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Dtos.Queries;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IAbsenceRepository
{
    Task<AbsenceDto> GetById(int id);
    Task<IEnumerable<AbsenceDto>> GetByQuery(AbsenceQueryDto query);
    Task<AbsenceDto> Create(AbsenceDto absenceDto);
    AbsenceDto Update(AbsenceDto absenceDto);
}