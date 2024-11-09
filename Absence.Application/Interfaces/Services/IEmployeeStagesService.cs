using Absence.Application.Models.Actions;
using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IEmployeeStagesService
{
    Task CreateOrSetFirstStatus(string pId, int year);
    Task SetFirstStatus(string pId, int year);
    Task UpdateBulk(UpdateStagesBulkView view);
}