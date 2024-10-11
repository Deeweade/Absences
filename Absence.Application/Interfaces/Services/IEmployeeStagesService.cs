using Vacations.Application.Models.Views;

namespace Vacations.Application.Interfaces.Services;

public interface IEmployeeStagesService
{
    Task CreateOrSetFirstStatus(string pId, int year);
    Task<EmployeeStatusView> ChangeStatus(EmployeeStatusView status);
}