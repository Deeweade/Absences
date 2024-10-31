using Absence.Application.Models.Queries;
using Absence.Application.Models.Actions;
using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IAbsenceService
{
    Task<List<AbsenceView>> GetByQuery(AbsenceQueryView query);
    Task<AbsenceView> Create(CreateAbsenceView view);

    /// <summary>
    /// Метод для изменения статусов отсутствий одного или нескольких сотрудников. При этом проставляются соответствующие
    /// статусы сотрудникам.
    /// </summary>
    /// <param name="view"></param>
    Task ChangeStatusesBulk(UpdateAbsencesBulkView view);
    Task ChangeStatus(ChangeAbsenceStatusView view);

    /// <summary>
    /// Метод для переноса отсутствия на один или несколько новых периодов. При переносе
    /// отменяется старое отсутствие и создаются черновики новых.
    /// </summary>
    /// <returns>Коллекция новых отсутствий</returns>
    Task<List<AbsenceView>> Reschedule(RescheduleAbsenceView view);
    Task<AbsenceView> Update(UpdateAbsenceView view);
    Task Delete(int id);
}