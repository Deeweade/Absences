using Absence.Domain.Dtos.Entities;

namespace Absence.Domain.Interfaces.Repositories;

public interface IVacationDaysRepository
{
    Task<List<VacationDaysDto>> GetAll(string pId, int year, bool isYearPlanning);
}