using Vacations.Application.Models.Queries;
using Vacations.Application.Models.Views;
using Vacations.Domain.Models.Enums;

namespace Vacations.Application.Interfaces.Services;

public interface IVacationService
{
    Task<IEnumerable<VacationView>> GetByQuery(VacationQueryView query);
    Task<VacationView> Create(VacationView vacationView);
    Task<VacationView> Update(VacationView vacationView);
}