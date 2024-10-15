using Absence.Domain.Dtos.Entities;

namespace Absence.Domain.Interfaces.Repositories;

public interface IVacationDaysRepository
{
    Task<VacationDaysDto> GetAvailableDays(string pId, int year, bool isYearPlanning);
}