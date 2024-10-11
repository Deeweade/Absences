using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;

namespace Absence.Domain.Interfaces.Repositories;

public interface IAbsenceRepository
{
    Task<AbsenceDto> GetById(int id);
    Task<IEnumerable<AbsenceDto>> GetByQuery(AbsenceQueryDto query);
    Task<AbsenceDto> Create(AbsenceDto absenceDto);
    AbsenceDto Update(AbsenceDto absenceDto);
}