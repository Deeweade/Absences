using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IVacationDaysService
{
    Task<List<VacationDaysView>> GetAvailableDaysNumber(string pId, int year);
}