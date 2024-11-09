using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IVacationDaysService
{
    Task<List<VacationDaysView>> GetAll(string pId, int year);
    /// <summary>
    /// Метод возвращает разницу между количеством обязательных к планированию дней и количеством запланированных дней
    /// </summary>
    /// <param name="pId">Табельный номер сотрудника</param>
    /// <param name="year">Год</param>
    Task<List<VacationDaysView>> GetRemainingDays(string pId, int year);
}