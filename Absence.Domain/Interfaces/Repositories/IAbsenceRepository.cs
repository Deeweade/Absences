using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;

namespace Absence.Domain.Interfaces.Repositories;

public interface IAbsenceRepository
{
    Task<AbsenceDto> GetById(int id);
    Task<int> GetVacationDaysSum(string pId, int year);
    Task<List<AbsenceDto>> GetByQuery(AbsenceQueryDto query);
    Task<AbsenceDto> Create(AbsenceDto absenceDto);
    Task<List<AbsenceDto>> CreateBulk(List<AbsenceDto> newAbsences);
    Task<AbsenceDto> Update(AbsenceDto absenceDto);
    void UpdateBulk(List<AbsenceDto> absences);
    Task Delete(int id);
}