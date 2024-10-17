using Absence.Application.Models.Queries;
using Absence.Application.Models.Actions;
using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IAbsenceService
{
    Task<IEnumerable<AbsenceView>> GetByQuery(AbsenceQueryView query);
    Task<AbsenceView> Create(AbsenceView view);

    /// <summary>
    /// Метод для изменения статусов отсутствий одного или нескольких сотрудников. При этом проставляются соответствующие
    /// статусы сотрудникам.
    /// </summary>
    /// <param name="view"></param>
    Task ChangeStatusesBulk(UpdateAbsencesBulkView view);

    /// <summary>
    /// Метод для переноса отсутствия на один или несколько новых периодов. При переносе
    /// отменяется старое отсутствие и создаются черновики новых.
    /// </summary>
    /// <returns>Коллекция новых отсутствий</returns>
    Task<IEnumerable<AbsenceView>> Reschedule(RescheduleAbsenceView view);
    Task<AbsenceView> Update(AbsenceView view);
    Task Delete(int id);
}