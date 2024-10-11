using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IEmployeeStagesService
{
    Task CreateOrSetFirstStatus(string pId, int year);
    Task<EmployeeStatusView> ChangeStatus(EmployeeStatusView status);
}