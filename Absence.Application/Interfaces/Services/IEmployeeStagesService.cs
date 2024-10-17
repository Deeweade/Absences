using Absence.Application.Models.Actions;
using Absence.Domain.Dtos.Entities;

namespace Absence.Application.Interfaces.Services;

public interface IEmployeeStagesService
{
    Task CreateOrSetFirstStatus(string pId, int year);
    Task SetFirstStatus(string pId, int year);
    Task UpdateStagesBulk(UpdateStagesBulkView view);
}