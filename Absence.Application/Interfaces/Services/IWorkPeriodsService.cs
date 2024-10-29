using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IWorkPeriodsService
{
    Task<List<WorkPeriodView>> GetAll();
}