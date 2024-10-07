using Vacations.Application.Models.Queries;
using Vacations.Application.Models.Views;

namespace Vacations.Application.Interfaces.Services;

public interface IAbsenceService
{
    Task<IEnumerable<AbsenceView>> GetByQuery(AbsenceQueryView query);
    Task<AbsenceView> Create(AbsenceView view);
    Task<AbsenceView> Update(AbsenceView view);
}