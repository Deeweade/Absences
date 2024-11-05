using Absence.Domain.Dtos.Entities;

namespace Absence.Domain.Interfaces.Repositories;

public interface IWorkPeriodsRepository
{
    Task<List<WorkPeriodDto>> GetAll();
    Task<int> GetHolidaysNumberInPeriods(List<AbsenceDto> activeAbsences);
}