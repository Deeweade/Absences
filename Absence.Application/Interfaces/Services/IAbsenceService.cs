using Absence.Application.Models.Queries;
using Absence.Application.Models.Actions;
using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IAbsenceService
{
    Task<IEnumerable<AbsenceView>> GetByQuery(AbsenceQueryView query);
    Task<AbsenceView> Create(AbsenceView view);
    Task ChangeStatusesBulk(UpdateAbsencesBulkView view);
    Task<AbsenceView> Update(AbsenceView view);
}