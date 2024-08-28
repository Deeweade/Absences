using Vacations.Application.Models.Queries;
using Vacations.Application.Models.Views;

namespace Vacations.Application.Interfaces.Services;

public interface IVacationService
{
    Task<VacationView> Create(VacationView vacationView);
    Task<IEnumerable<VacationView>> GetByQuery(VacationQueryView query);
}