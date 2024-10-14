using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;

namespace Absence.Domain.Interfaces.Repositories;

public interface IAbsenceRepository
{
    Task<AbsenceDto> GetById(int id);
    Task<List<AbsenceDto>> GetByQuery(AbsenceQueryDto query);
    Task<AbsenceDto> Create(AbsenceDto absenceDto);
    Task<AbsenceDto> Update(AbsenceDto absenceDto);
    void UpdateBulk(List<AbsenceDto> absences);
}