using Vacations.Application.Models.Filters;
using Vacations.Application.Models.Views;

namespace Vacations.Application.Interfaces.Services;

public interface IVacationService
{
    Task<VacationView> Create(VacationView vacationView);
    Task<IEnumerable<VacationView>> GetByFilter(VacationFilterView filter);
}