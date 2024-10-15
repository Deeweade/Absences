using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IVacationDaysService
{
    Task<VacationDaysView> GetAvailableDaysNumber(string pId, int year);
}